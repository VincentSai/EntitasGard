//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public IDComponent iD { get { return (IDComponent)GetComponent(InputComponentsLookup.ID); } }
    public bool hasID { get { return HasComponent(InputComponentsLookup.ID); } }

    public void AddID(int newValue) {
        var index = InputComponentsLookup.ID;
        var component = CreateComponent<IDComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceID(int newValue) {
        var index = InputComponentsLookup.ID;
        var component = CreateComponent<IDComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveID() {
        RemoveComponent(InputComponentsLookup.ID);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity : IID { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherID;

    public static Entitas.IMatcher<InputEntity> ID {
        get {
            if (_matcherID == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.ID);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherID = matcher;
            }

            return _matcherID;
        }
    }
}
