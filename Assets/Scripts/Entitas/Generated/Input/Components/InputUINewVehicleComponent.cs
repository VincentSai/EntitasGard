//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    static readonly UINewVehicle uINewVehicleComponent = new UINewVehicle();

    public bool isUINewVehicle {
        get { return HasComponent(InputComponentsLookup.UINewVehicle); }
        set {
            if (value != isUINewVehicle) {
                var index = InputComponentsLookup.UINewVehicle;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : uINewVehicleComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherUINewVehicle;

    public static Entitas.IMatcher<InputEntity> UINewVehicle {
        get {
            if (_matcherUINewVehicle == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.UINewVehicle);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherUINewVehicle = matcher;
            }

            return _matcherUINewVehicle;
        }
    }
}
