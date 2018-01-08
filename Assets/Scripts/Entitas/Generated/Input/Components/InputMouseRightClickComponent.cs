//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    static readonly MouseRightClick mouseRightClickComponent = new MouseRightClick();

    public bool isMouseRightClick {
        get { return HasComponent(InputComponentsLookup.MouseRightClick); }
        set {
            if (value != isMouseRightClick) {
                var index = InputComponentsLookup.MouseRightClick;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : mouseRightClickComponent;

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

    static Entitas.IMatcher<InputEntity> _matcherMouseRightClick;

    public static Entitas.IMatcher<InputEntity> MouseRightClick {
        get {
            if (_matcherMouseRightClick == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.MouseRightClick);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherMouseRightClick = matcher;
            }

            return _matcherMouseRightClick;
        }
    }
}