using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using Avalonia.Interactivity;
using Beataroni.Models.BeatMods;
using Beataroni.Services;
using ReactiveUI;

namespace Beataroni.ViewModels
{
  /*
   * Adapter class/view model between mod list and Observable collection
   */
  public class ModsViewModel : ViewModelBase
  {
    public class ModEntry
    {
      public Mod mod { get; set; }
      public bool selected { get; set; } = false;
    }

    private ObservableCollection<ModEntry> mods = null;
    public ObservableCollection<ModEntry> Mods
    {
      get { return mods; }
    }

    public ReactiveCommand<ModEntry, Unit> ModChecked { get; }

    public ModsViewModel()
    {
      ModChecked = ReactiveCommand.Create<ModEntry>(x =>
      {
        // If a mod has been selected make sure all it's requirements are also selected
        // TODO: This action could be improved
        if( x.selected )
        {
          var deps = new HashSet<Mod>();
          Mod.GetDependencySet(x.mod, ref deps);

          foreach (var d in deps)
          {
            ModEntry entry = null;
            foreach (var m in Mods)
            {
              if (m.mod == d)
              {
                entry = m;
                break;
              }
            }
            if (entry != null)
            {
              // TODO: This little dance notifies the collection that something has changed, but it's not the best approach
              var index = Mods.IndexOf(entry);
              Mods.RemoveAt(index);
              entry.selected = true;
              Mods.Insert(index, entry);
            }
          }
        }
        // If a mod was deselected make sure anything that requires it is also deselected
        else
        {
          var dependents = new HashSet<Mod>();
          foreach( var m in Mods )
          {
            var deps = new HashSet<Mod>();
            Mod.GetDependencySet(m.mod, ref deps);
            if (deps.Contains(x.mod)) dependents.Add(m.mod);
          }

          foreach( var d in dependents )
          {
            ModEntry entry = null;
            foreach (var m in Mods)
            {
              if (m.mod == d)
              {
                entry = m;
                break;
              }
            }
            if (entry != null)
            {
              // TODO: This little dance notifies the collection that something has changed, but it's not the best approach
              var index = Mods.IndexOf(entry);
              Mods.RemoveAt(index);
              entry.selected = false;
              Mods.Insert(index, entry);
            }
          }
        }
      });
    }

    public void FetchMods(string gameVersion)
    {
      // TODO: Need filters from somewhere - This shouldn't be called until version/etc has been selected?
      var filters = BeatModsV1.DefaultFilters;
      filters.Add("gameVersion", gameVersion);

      var m = BeatModsV1.FetchMods(BeatModsV1.DefaultFilters);

      var entries = new List<ModEntry>();
      foreach( var mm in m ) entries.Add(new ModEntry() { mod = mm });

      mods = new ObservableCollection<ModEntry>(entries);
    }
  }
}
