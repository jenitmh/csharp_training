﻿using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    public class GroupTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareFroupsUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<GroupData> fromUI = app.Groups.GetGroupList();
                List<GroupData> fromDB = GroupData.GetAll();

                fromUI.Sort();
                fromDB.Sort();

                Assert.AreEqual(fromUI, fromDB);
            }
        }
    }
}