﻿using Entitas;
using System;
using UnityEngine;

namespace Systems.Command.Execution
{
    public class AimGun : IExecuteSystem
    {
        public const float NEAR_ZERO = 5f;
        GameContext _game;
        IGroup<GameEntity> _attackingUnits;

        public AimGun(Contexts contexts)
        {
            _game = contexts.game;
            _attackingUnits = _game.GetGroup(GameMatcher.AllOf(GameMatcher.AttackTarget, GameMatcher.Weapon, GameMatcher.WeaponRotation));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var attacker in _attackingUnits)
            {
                GameEntity defender = _game.GetEntityWithID(attacker.attackTarget.targetID);
                float mustRotate = CalcRotationY(attacker.worldCoordinates, defender.worldCoordinates, attacker.weapon, attacker.weaponRotation);
                if (Math.Abs(mustRotate) < NEAR_ZERO)
                {
                    attacker.isWeaponAimed = true;
                    attacker.ReplaceRotateWeapon(mustRotate);
                }
                else
                {
                    attacker.isWeaponAimed = false;
                    attacker.ReplaceRotateWeapon(mustRotate);
                }
            }
        }

        private float CalcRotationY(WorldCoordinatesComponent attacker, WorldCoordinatesComponent defender, WeaponComponent weapon, WeaponRotation wr)
        {
            Vector3 dir = CalcVector3(attacker, defender);

            Quaternion from = Quaternion.Euler(0, wr.ry, 0);
            //Quaternion from = new Quaternion(attacker.rx, attacker.ry, attacker.rz, attacker.rw);
            Quaternion to = Quaternion.LookRotation(dir, Vector3.up);
            Quaternion res = Quaternion.RotateTowards(from, to, weapon.rotationSpeed * Time.deltaTime);
            return Mathf.DeltaAngle(from.eulerAngles.y, res.eulerAngles.y);
        }

        private Vector3 CalcVector3(WorldCoordinatesComponent attacker, WorldCoordinatesComponent defender)
        {
            Vector3 res = new Vector3(
                defender.x - attacker.x,
                defender.y - attacker.y,
                defender.z - attacker.z
                ).normalized;

            return res;
        }
    }
}
