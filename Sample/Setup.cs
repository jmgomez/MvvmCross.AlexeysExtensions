﻿using Cirrious.MvvmCross.Application;
using Cirrious.MvvmCross.Binding.Binders;
using Cirrious.MvvmCross.Binding.Interfaces.Parse;
using Cirrious.MvvmCross.Binding.Parse.Binding.Swiss;
using Cirrious.MvvmCross.Dialog.Touch;
using Cirrious.MvvmCross.Platform;
using Cirrious.MvvmCross.Plugins.Visibility;
using Cirrious.MvvmCross.Touch.Interfaces;
using Cirrious.MvvmCross.Touch.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample
{
    public class Setup
        : MvxTouchDialogBindingSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, IMvxTouchViewPresenter presenter)
            : base(applicationDelegate, presenter)
        {
        }

        protected override MvxApplication CreateApp()
        {
            var app = new SampleApplication();
            return app;
        }

        protected override void FillValueConverters(Cirrious.MvvmCross.Binding.Interfaces.Binders.IMvxValueConverterRegistry registry)
        {
            base.FillValueConverters(registry);

            var filler = new MvxInstanceBasedValueConverterRegistryFiller(registry);
            filler.AddFieldConverters(typeof(Converters));
        }


        protected override void AddPluginsLoaders(MvxLoaderPluginRegistry registry)
        {
            registry.AddConventionalPlugin<Cirrious.MvvmCross.Plugins.Visibility.Touch.Plugin>();
            registry.AddConventionalPlugin<Cirrious.MvvmCross.Plugins.File.Touch.Plugin>();
            registry.AddConventionalPlugin<Cirrious.MvvmCross.Plugins.DownloadCache.Touch.Plugin>();
            base.AddPluginsLoaders(registry);
        }

    }

    public class Converters
    {
        public readonly MvxVisibilityConverter Visibility = new MvxVisibilityConverter();
        public readonly MvxInvertedVisibilityConverter InvertedVisibility = new MvxInvertedVisibilityConverter();
    }
}
