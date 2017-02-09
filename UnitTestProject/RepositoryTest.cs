using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xyz.ibean.data;
using CrRepairs.model;
using System.Collections.Generic;
using System.Diagnostics;
using CrRepairs.util;

namespace UnitTestProject
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void addLocationTest()
        {
            Repository repository = Repository.newInstance();
            Location location = new Location();
            location.LocationID = Guid.NewGuid().ToString();
            location.LocationPID = Guid.NewGuid().ToString();
            location.LocationName = "联发新天地1";
            location.LocationFullName = "联发新天地1";
            location.LocationCode = StringUtil.GetSpellCode("项目名称-" + location.LocationName);
            location.LocationLevel = 0;
            Assert.IsNotNull(repository.addLocation(location));
        }

        [TestMethod]
        public void deleteLocationTest()
        {
            Repository repository = Repository.newInstance();
            Assert.IsTrue(repository.deleteLocation("sdfsdf1"));
        }

        [TestMethod]
        public void updateLocationTest()
        {
            Repository repository = Repository.newInstance();
            Location location = new Location();
            location.LocationID = Guid.Empty.ToString();
            location.LocationPID = "111";
            location.LocationName = "111";
            location.LocationFullName = "111";
            location.LocationCode = "111";
            Assert.IsTrue(repository.updateLocation(location));
        }

        [TestMethod]
        public void updateLocationIDTest()
        {
            Repository repository = Repository.newInstance();
            Location location = new Location();
            location.LocationID = "eb58f44b-978a-4e10-8d4c-788b7cde53ff";
            location.LocationPID = "111";
            location.LocationName = "111";
            location.LocationFullName = "111";
            location.LocationCode = "111";
            Assert.IsTrue(repository.updateLocation(location));
        }

        [TestMethod]
        public void getLocations()
        {
            Repository repository = Repository.newInstance();
            List<Location> locations = repository.getLocations();
            Debug.WriteLine("地址数" + (locations.Count));
            Assert.IsNotNull(locations);
            Assert.IsTrue(locations.Count > 0);
        }
    }
}
