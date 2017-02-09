using Nancy;
using CDOrganizer.Objects;
using System.Collections.Generic;

namespace CDOrganizer
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        var allArtists = Artist.GetAll();
        return View["all_artists.cshtml", allArtists];
      };

      Get["/new-artist"] = _ => {
        return View["artist_form.cshtml"];
      };

      Post["/"] = _ => {
        var newArtist = new Artist(Request.Form["artist-name"]);
        var allArtists = Artist.GetAll();
        return View["all_artists.cshtml", allArtists];
      };

      Get["/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedArtist = Category.Find(parameters.id);
        var artistCds = selectedArtist.GetCds();
        model.Add("artist", selectedArtist);
        model.Add("cds", artistCds);
        return View["artist.cshtml", model];
      };

      Get["/{id}/cds/new"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedArtist = Category.Find(parameters.id);
        var artistCds = selectedArtist.GetCds();
        model.Add("artist", selectedArtist);
        model.Add("cds", artistCds);
        return View["cd_form.cshtml", model];
      };

      Post["/cds"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedArtist = Category.Find(parameters.id);
        var artistCds = selectedArtist.GetCds();
        CD newCd = new CD(cdDescription)
        model.Add("artist", selectedArtist);
        model.Add("cds", artistCds);
        return View["artist.cshtml", model];
      }

      // Get["/"] = _ => {
      //   var allCds = CD.GetAll();
      //   return View["all_cds.cshtml", allCds];
      // };
      //
      // Get["/new"] = _ => {
      //   return View["cd_form.cshtml"];
      // };
      //
      // Post["/"] = _ => {
      //   var newCd = new CD(Request.Form["cd-name"]);
      //   var allCds = CD.GetAll();
      //   return View["all_cds.cshtml", allCds];
      // };


    }
  }
}
