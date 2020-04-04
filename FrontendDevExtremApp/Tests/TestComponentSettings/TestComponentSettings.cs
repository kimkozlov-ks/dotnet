﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using DataModel;

namespace Tests.TestComponentSettings
{
    public class TestComponentSettings
    {
        [Fact]
        public void TestComponentSettingsCtor()
        {
            string settings = null;
            var componentSettings = new ComponentSettings(settings);

            Assert.False(componentSettings.IsCity);
            Assert.False(componentSettings.IsEmail);
            Assert.False(componentSettings.IsGender);
            Assert.False(componentSettings.IsPhone);
            Assert.False(componentSettings.IsStreet);

            settings = string.Empty;
            var componentSettings2 = new ComponentSettings(settings);

            Assert.False(componentSettings2.IsCity);
            Assert.False(componentSettings2.IsEmail);
            Assert.False(componentSettings2.IsGender);
            Assert.False(componentSettings2.IsPhone);
            Assert.False(componentSettings2.IsStreet);

            settings = "City,Street,Email,Gender,Phone";
            var componentSettings3 = new ComponentSettings(settings);

            Assert.True(componentSettings3.IsCity);
            Assert.True(componentSettings3.IsEmail);
            Assert.True(componentSettings3.IsGender);
            Assert.True(componentSettings3.IsPhone);
            Assert.True(componentSettings3.IsStreet);
        }
    }
}
