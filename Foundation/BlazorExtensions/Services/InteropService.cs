﻿using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Browser.Interop;
using SitecoreBlazorHosted.Shared.Models;
using System;

namespace Foundation.BlazorExtensions.Services
{
  public class InteropService
  {
    public Action RenderHtmlAction;

    public string RenderHtml(BlazorSitecoreField<string> htmlField, string elementId)
    {
      RenderHtmlAction = () => ShowRawHtml(htmlField.Value, elementId);
      return null;
    }

    public string RawHtml(BlazorSitecoreField<string> htmlField, ElementRef element)
    {
      RenderHtmlAction = () => HtmlRaw(htmlField.Value, element);
      return null;
    }

    public string JsonValue(string field, string jsonData)
    {
      return GetJsonValue(field, jsonData);
    }

    public bool ReloadBlazor()
    {
      return HardReload();
    }

    private static string ShowRawHtml(string htmlContent, string elementId)
    {
      return RegisteredFunction.Invoke<string>("Foundation.BlazorExtensions.BlazorExtensionsInterop.ShowRawHtml", elementId, htmlContent);
    }

    private static string GetJsonValue(string field, string jsonData)
    {
      return RegisteredFunction.Invoke<string>("Foundation.BlazorExtensions.BlazorExtensionsInterop.GetJsonValue", field, jsonData);
    }

    private static bool HtmlRaw(string htmlContent, ElementRef element)
    {
      return RegisteredFunction.Invoke<bool>("Foundation.BlazorExtensions.BlazorExtensionsInterop.RawHtml", element, htmlContent);
    }

    public static bool HardReload()
    {
      return RegisteredFunction.Invoke<bool>("Foundation.BlazorExtensions.BlazorExtensionsInterop.HardReload");
    }



  }


}
