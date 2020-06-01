﻿using ReactiveMvvm.Interfaces;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReactiveMvvm.WinForms.Services
{
    public sealed class WinFormsSender : ISender
    {
        public Task Send(string title, string message, int section, bool bug)
        {
            var content = $"{message}, Bug: {bug}, Section: {section}";
            MessageBox.Show(content, title);
            return Task.CompletedTask;
        }
    }
}
