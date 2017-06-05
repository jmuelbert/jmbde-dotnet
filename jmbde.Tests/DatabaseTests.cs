using System;
using GenFu;
using Xunit;


using jmbde.Data;
using jmbde.Tests.GenData;

namespace jmbde.Tests
{
    public class DatabaseTests
    {
        // var optionsBuilder = new DbContextoptionsBuilder();
        // optionsBuilder.UseSqlite("Data Source=../../..jmbdesqlite.db");

        static int MAXEMPLOYEE = 200;
        static int MAXCOMPUTER = (MAXEMPLOYEE / 3) * 2;
        static int MAXMOBILE = MAXEMPLOYEE / 4;
        static int MAXACCOUNT = MAXEMPLOYEE / 5;

        static int MAXPHONE = (MAXEMPLOYEE / 4) * 3;
        Random rnd = new Random();

        [Fact]
        public void TestDatabase()
        { }
        
        [Fact]
        public void TestAccountData() {
            AccountSampler accountSampler = new AccountSampler(MAXACCOUNT);
            accountSampler.ToDatabase();
        }

        [Fact]
        public void TestChipcardData() {
            ChipcardSampler  chipcardSampler = new ChipcardSampler(MAXACCOUNT);
            chipcardSampler.ToDatabase();
        }

        [Fact]
        public void TestEmployeeData() {
            EmployeeSampler  es = new EmployeeSampler(MAXEMPLOYEE);    
            es.ToDatabase();
        }

        [Fact]
        public void TestComputerData() {
            ComputerSampler cs = new ComputerSampler(MAXCOMPUTER);
            cs.ToDatabase();            
        }

        [Fact]
        public void TestMobileData() {
            MobileSampler ms = new MobileSampler(MAXMOBILE);
            ms.ToDatabase();
        }

        [Fact]
        public void TestPhoneData() {
            PhoneSampler ps = new PhoneSampler(MAXPHONE);
            ps.ToDatabase();
        }

    }

}