//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public RotateWeapon rotateWeapon { get { return (RotateWeapon)GetComponent(GameComponentsLookup.RotateWeapon); } }
    public bool hasRotateWeapon { get { return HasComponent(GameComponentsLookup.RotateWeapon); } }

    public void AddRotateWeapon(float newRy) {
        var index = GameComponentsLookup.RotateWeapon;
        var component = CreateComponent<RotateWeapon>(index);
        component.ry = newRy;
        AddComponent(index, component);
    }

    public void ReplaceRotateWeapon(float newRy) {
        var index = GameComponentsLookup.RotateWeapon;
        var component = CreateComponent<RotateWeapon>(index);
        component.ry = newRy;
        ReplaceComponent(index, component);
    }

    public void RemoveRotateWeapon() {
        RemoveComponent(GameComponentsLookup.RotateWeapon);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherRotateWeapon;

    public static Entitas.IMatcher<GameEntity> RotateWeapon {
        get {
            if (_matcherRotateWeapon == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.RotateWeapon);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherRotateWeapon = matcher;
            }

            return _matcherRotateWeapon;
        }
    }
}
