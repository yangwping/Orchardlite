using System;
using System.Linq;
using JetBrains.Annotations;
using Orchard.Caching;
using Orchard.Core.Settings.Models;
using Orchard.Logging;
using Orchard.Settings;

namespace Orchard.Core.Settings.Services {
    [UsedImplicitly]
    public class SiteService : ISiteService {
        private readonly ICacheManager _cacheManager;

        public SiteService(
            ICacheManager cacheManager) {
            _cacheManager = cacheManager;
            Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }

        public ISite GetSiteSettings() {
            var siteId = _cacheManager.Get("SiteId", ctx => {
                ISite site = null;
               
                if (site == null) {
                    //site = _contentManager.Create<SiteSettingsPart>("Site", item => {
                    //    item.SiteSalt = Guid.NewGuid().ToString("N");
                    //    item.SiteName = "My Orchard Project Application";
                    //    item.PageTitleSeparator = " - ";
                    //    item.SiteTimeZone = TimeZoneInfo.Local.Id;
                    //}).ContentItem;
                }

                return 1;
            });

            var site1 = new SiteSettingsPart();
            site1.SiteName = "wode";
            site1.PageSize = 10;
            site1.BaseUrl = "http://localhost:30322/OrchardLocal/";
            site1.SiteCulture = "en-US";
            return site1;
        }
    }
}