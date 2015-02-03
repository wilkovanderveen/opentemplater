﻿namespace OpenTemplater.Services
{
    public interface IElementCreationInput
    {
        string Key { get; }
        string Name { get; }
        IElementLayoutInput LayoutInput { get; }
    }
}