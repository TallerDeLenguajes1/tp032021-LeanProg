#pragma checksum "C:\Users\Leandro\Documents\GitHub\tp032021-LeanProg\EmpresaCadetes\EmpresaCadetes\Views\Pedidos\MostrarPedidos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "78d2047fb677f4be7e6160e7b00dca005a0aadac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pedidos_MostrarPedidos), @"mvc.1.0.view", @"/Views/Pedidos/MostrarPedidos.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Leandro\Documents\GitHub\tp032021-LeanProg\EmpresaCadetes\EmpresaCadetes\Views\_ViewImports.cshtml"
using EmpresaCadetes;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Leandro\Documents\GitHub\tp032021-LeanProg\EmpresaCadetes\EmpresaCadetes\Views\_ViewImports.cshtml"
using EmpresaCadetes.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"78d2047fb677f4be7e6160e7b00dca005a0aadac", @"/Views/Pedidos/MostrarPedidos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fbd6701b05a2137a17a848ed698c9339fc61f6ae", @"/Views/_ViewImports.cshtml")]
    public class Views_Pedidos_MostrarPedidos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tuple<List<EmpresaCadetes.ViewModels.PedidosViewModel>,EmpresaCadetes.ViewModels.UsuarioViewModel,List<EmpresaCadetes.ViewModels.CadeteViewModel>>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Pedidos", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "FormularioPedido", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("idPedido"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EliminarPedido", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "FormularioModificar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PedidoAcadete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "Post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 7 "C:\Users\Leandro\Documents\GitHub\tp032021-LeanProg\EmpresaCadetes\EmpresaCadetes\Views\Pedidos\MostrarPedidos.cshtml"
Write(await Html.PartialAsync("_NavAdminPartial",Model.Item2));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"text-center\">\r\n    <br />\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "78d2047fb677f4be7e6160e7b00dca005a0aadac7973", async() => {
                WriteLiteral("Alta de Pedidos");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</div>
<br />
<div class=""text-center"">
    <h1 class=""display-4"">ASIGNAR PEDIDOS A CADETES</h1>

    <div class=""container"">
        <div class=""row"">
            <div hidden>   </div>
            <div class=""col-sm"">
                <h3>Nro</h3>
            </div>
            <div class=""col-sm"">
                <h3>Detalle</h3>
            </div>
            <div class=""col-sm"">
                <h3>Cliente</h3>
            </div>
            <div class=""col-sm"">
                <h3>Estado</h3>
            </div>
            <div class=""col-sm"">
                <h3 >Aciones</h3>
            </div>
            <div class=""col-sm"">
                <h3>Asignar Cadete</h3>
            </div>
            <div class=""col-sm"">
                <h3>Acciones</h3>
            </div>
            <div class=""col-sm"">
                <h3>Modificar Pedido</h3>
            </div>


        </div>



");
#nullable restore
#line 50 "C:\Users\Leandro\Documents\GitHub\tp032021-LeanProg\EmpresaCadetes\EmpresaCadetes\Views\Pedidos\MostrarPedidos.cshtml"
         foreach (var item in Model.Item1)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "78d2047fb677f4be7e6160e7b00dca005a0aadac10968", async() => {
                WriteLiteral("\r\n                <div class=\"row\">\r\n                    <div hidden> <input hidden type=\"number\" name=\"idPedido\"");
                BeginWriteAttribute("value", " value=\"", 1708, "\"", 1728, 1);
#nullable restore
#line 55 "C:\Users\Leandro\Documents\GitHub\tp032021-LeanProg\EmpresaCadetes\EmpresaCadetes\Views\Pedidos\MostrarPedidos.cshtml"
WriteAttributeValue("", 1716, item.Numero, 1716, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /> </div>\r\n                    <div class=\"col-sm\">\r\n                        <p> ");
#nullable restore
#line 57 "C:\Users\Leandro\Documents\GitHub\tp032021-LeanProg\EmpresaCadetes\EmpresaCadetes\Views\Pedidos\MostrarPedidos.cshtml"
                       Write(item.Numero);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </p>\r\n                    </div>\r\n                    <div class=\"col-sm\">\r\n                        <p>");
#nullable restore
#line 60 "C:\Users\Leandro\Documents\GitHub\tp032021-LeanProg\EmpresaCadetes\EmpresaCadetes\Views\Pedidos\MostrarPedidos.cshtml"
                      Write(item.Observacion);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n\r\n                    </div>\r\n                    <div class=\"col-sm\">\r\n                       <ul>\r\n                           <li>Nombre: ");
#nullable restore
#line 65 "C:\Users\Leandro\Documents\GitHub\tp032021-LeanProg\EmpresaCadetes\EmpresaCadetes\Views\Pedidos\MostrarPedidos.cshtml"
                                  Write(item.NewCliente.Nombre);

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n                           <li>Direcion: ");
#nullable restore
#line 66 "C:\Users\Leandro\Documents\GitHub\tp032021-LeanProg\EmpresaCadetes\EmpresaCadetes\Views\Pedidos\MostrarPedidos.cshtml"
                                    Write(item.NewCliente.Direccion);

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n                           <li>Telefono: ");
#nullable restore
#line 67 "C:\Users\Leandro\Documents\GitHub\tp032021-LeanProg\EmpresaCadetes\EmpresaCadetes\Views\Pedidos\MostrarPedidos.cshtml"
                                    Write(item.NewCliente.Telefono);

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n                       </ul> \r\n                        \r\n                    </div>\r\n                    <div class=\"col-sm\">\r\n                        <p> ");
#nullable restore
#line 72 "C:\Users\Leandro\Documents\GitHub\tp032021-LeanProg\EmpresaCadetes\EmpresaCadetes\Views\Pedidos\MostrarPedidos.cshtml"
                       Write(item.Estado);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n\r\n                    </div>\r\n\r\n                    <div class=\"col-sm\">\r\n                        <select class=\"align-items-xl-baseline\" name=\"idCadete\">\r\n");
#nullable restore
#line 78 "C:\Users\Leandro\Documents\GitHub\tp032021-LeanProg\EmpresaCadetes\EmpresaCadetes\Views\Pedidos\MostrarPedidos.cshtml"
                             foreach (var cadete in Model.Item3)
                            {
                                
                                if (cadete.Listapedidos.Exists(a => a.Numero == item.Numero))
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "78d2047fb677f4be7e6160e7b00dca005a0aadac14851", async() => {
                    WriteLiteral("  ");
#nullable restore
#line 83 "C:\Users\Leandro\Documents\GitHub\tp032021-LeanProg\EmpresaCadetes\EmpresaCadetes\Views\Pedidos\MostrarPedidos.cshtml"
                                                                     Write(cadete.Nombre);

#line default
#line hidden
#nullable disable
                    WriteLiteral(" (");
#nullable restore
#line 83 "C:\Users\Leandro\Documents\GitHub\tp032021-LeanProg\EmpresaCadetes\EmpresaCadetes\Views\Pedidos\MostrarPedidos.cshtml"
                                                                                     Write(cadete.Listapedidos.Count());

#line default
#line hidden
#nullable disable
                    WriteLiteral(") ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 83 "C:\Users\Leandro\Documents\GitHub\tp032021-LeanProg\EmpresaCadetes\EmpresaCadetes\Views\Pedidos\MostrarPedidos.cshtml"
                                                WriteLiteral(cadete.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 84 "C:\Users\Leandro\Documents\GitHub\tp032021-LeanProg\EmpresaCadetes\EmpresaCadetes\Views\Pedidos\MostrarPedidos.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "78d2047fb677f4be7e6160e7b00dca005a0aadac17988", async() => {
                    WriteLiteral("  ");
#nullable restore
#line 87 "C:\Users\Leandro\Documents\GitHub\tp032021-LeanProg\EmpresaCadetes\EmpresaCadetes\Views\Pedidos\MostrarPedidos.cshtml"
                                                            Write(cadete.Nombre);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 87 "C:\Users\Leandro\Documents\GitHub\tp032021-LeanProg\EmpresaCadetes\EmpresaCadetes\Views\Pedidos\MostrarPedidos.cshtml"
                                       WriteLiteral(cadete.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 88 "C:\Users\Leandro\Documents\GitHub\tp032021-LeanProg\EmpresaCadetes\EmpresaCadetes\Views\Pedidos\MostrarPedidos.cshtml"
                                }

                            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        </select>

                    </div>
                    <div class=""col"">
                        <input class=""btn bg-success"" type=""submit"" value=""Seleccionar"" />
                    </div>
                    <div class=""col"">
                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "78d2047fb677f4be7e6160e7b00dca005a0aadac20603", async() => {
                    WriteLiteral("Eliminar");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-idPedido", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 98 "C:\Users\Leandro\Documents\GitHub\tp032021-LeanProg\EmpresaCadetes\EmpresaCadetes\Views\Pedidos\MostrarPedidos.cshtml"
                                                                          WriteLiteral(item.Numero);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["idPedido"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-idPedido", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["idPedido"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    </div>\r\n                    <div class=\"col\">\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "78d2047fb677f4be7e6160e7b00dca005a0aadac23437", async() => {
                    WriteLiteral("Modificar");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-idPedido", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 101 "C:\Users\Leandro\Documents\GitHub\tp032021-LeanProg\EmpresaCadetes\EmpresaCadetes\Views\Pedidos\MostrarPedidos.cshtml"
                                                                        WriteLiteral(item.Numero);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["idPedido"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-idPedido", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["idPedido"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_9.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 105 "C:\Users\Leandro\Documents\GitHub\tp032021-LeanProg\EmpresaCadetes\EmpresaCadetes\Views\Pedidos\MostrarPedidos.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n\r\n");
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tuple<List<EmpresaCadetes.ViewModels.PedidosViewModel>,EmpresaCadetes.ViewModels.UsuarioViewModel,List<EmpresaCadetes.ViewModels.CadeteViewModel>>> Html { get; private set; }
    }
}
#pragma warning restore 1591
