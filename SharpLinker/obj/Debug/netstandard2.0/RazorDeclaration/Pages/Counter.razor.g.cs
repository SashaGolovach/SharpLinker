#pragma checksum "C:\Projects\SharpLinker\SharpLinker\Pages\Counter.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aa7c362686b3c47a8b3c8a4e086d248d4f35e1c1"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace SharpLinker.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#line 1 "C:\Projects\SharpLinker\SharpLinker\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#line 2 "C:\Projects\SharpLinker\SharpLinker\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#line 3 "C:\Projects\SharpLinker\SharpLinker\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#line 4 "C:\Projects\SharpLinker\SharpLinker\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#line 5 "C:\Projects\SharpLinker\SharpLinker\_Imports.razor"
using SharpLinker;

#line default
#line hidden
#line 6 "C:\Projects\SharpLinker\SharpLinker\_Imports.razor"
using SharpLinker.Shared;

#line default
#line hidden
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/counter")]
    public class Counter : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
        }
        #pragma warning restore 1998
#line 9 "C:\Projects\SharpLinker\SharpLinker\Pages\Counter.razor"
       
    int currentCount = 0;

    void IncrementCount()
    {
        currentCount+=5;
    }

#line default
#line hidden
    }
}
#pragma warning restore 1591
