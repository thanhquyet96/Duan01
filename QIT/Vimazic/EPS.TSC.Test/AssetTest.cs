using AutoMapper;
using EPS.TSC.Data;
using EPS.TSC.Data.Entities;
using EPS.TSC.Data.Entities.AssetInfo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace EPS.TSC.Test
{
    [TestClass]
    public class AssetTest
    {
        private TSCContext _dbContext;

        [TestInitialize]
        public void Initialize()
        {
            _dbContext = new TSCContext();
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }

        [TestMethod]
        public void SimpleTest()
        {
            var newAsset = new ASSET();

            newAsset.ID = DateTime.Now.Ticks;
            newAsset.SYNC_USER_ID = 1;
            newAsset.SYNC_SOURCE_ID = Guid.NewGuid().ToString();
            newAsset.SYNC_DATE = DateTime.Now;
            newAsset.LAST_UPDATED_DATE = DateTime.Now;
            newAsset.NAME = "Tai san test";
            newAsset.ASSET_TYPE_ID = 2;
            newAsset.UNIT_ID = 1;
            newAsset.CODE = "1";
            newAsset.ASSET_CATEGORY_ID = 1;


            newAsset.NPA.LAND.AREA = 10000;
            newAsset.OA.HOUSE.AREA_BUILDING = 20000;

            _dbContext.ASSETS.Add(newAsset);
            _dbContext.SaveChanges();

            var findAsset = _dbContext.ASSETS.FirstOrDefault(x => x.ID == newAsset.ID);

            Assert.IsNotNull(findAsset);
            Assert.AreEqual(findAsset.NPA.LAND.AREA, 10000);
            Assert.AreEqual(findAsset.OA.HOUSE.AREA_BUILDING, 20000);
        }

        [TestMethod]
        public void UserTest()
        {
            try
            {
                //var user = _dbContext.USERS.Find(1);
                var assetType = _dbContext.ASSET_TYPES.Find(3);
                var model = _dbContext.ASSETS.Find((long)1);
                var unit = _dbContext.UNITS.Find(9457);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [TestMethod]
        public void MappingTest()
        {
            try
            {

                var config = new MapperConfiguration(cfg =>
                {
                    //cfg.CreateMap<Foo, Bar>();
                    cfg.AddProfile<MyProfile>();
                    cfg.AddProfile<MyProfile2>();

                    cfg.CreateMap<Level1Source, Level1Destination>();
                    cfg.CreateMap<Level2Source, Level2Destination>();
                    cfg.CreateMap<Level3Source, Level3Destination>();

                    cfg.CreateMap<Level1Source, Destination>();
                });
                var mapper = config.CreateMapper();

                var source = new ASSET();
                source.ID = 123456;
                source.NPA.LAND.ADDRESS = "AAAAA";
                source.ASSET_CATEGORY_ID = 1;
                var destination = mapper.Map<AssetNpaLandDetailDto>(source);

                Assert.AreEqual(source.ASSET_CATEGORY_ID, destination.AssetCategoryId);

                var dest2 = mapper.Map<ASSET>(destination);

                //var levelSource = new Level1Source();
                //levelSource.Level2 = new Level2Source();
                //levelSource.Level2.Level3 = new Level3Source();
                //levelSource.Level2.Level3.Value = "ABC";

                //var levelDestination = mapper.Map<Level1Destination>(levelSource);

                //var destination = mapper.Map<Destination>(levelSource);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [TestMethod]
        public void InsertDataAsset()
        {
            var newAsset = new ASSET();
            newAsset.NPA.LAND.ADDRESS = "haf nooi ";
            newAsset.NPA.LAND.AREA = 1000000;
            newAsset.NPA.LAND.AREA_BUSINESS_USAGE = 10000;
            newAsset.NAME = "tài sản NPA Land";
            newAsset.ASSET_CATEGORY_ID = 1;
            newAsset.ASSET_TYPE_ID = 21;
            newAsset.CODE = "01";
            newAsset.SYNC_SOURCE_ID = "1";
            newAsset.SYNC_USER_ID = 1;
            newAsset.UNIT_ID = 1;
            newAsset.ID = 10;
            _dbContext.ASSETS.Add(newAsset);



            var newAsset2 = new ASSET();
            newAsset2.NPA.HOUSE.NUMBER_OF_FLOOR = 3200;
            newAsset2.NPA.HOUSE.AREA_BUILDING = 5400;
            newAsset2.NPA.HOUSE.AREA_BUSINESS_USAGE = 10000;
            newAsset2.NPA.HOUSE.AREA_FLOOR = 4000;
            newAsset2.NPA.HOUSE.AREA_HEADQUARTER_USAGE = 300;
            newAsset2.NPA.HOUSE.AREA_HOUSE_USAGE = 5000;
            newAsset2.NPA.HOUSE.AREA_WAREHOUSE_USAGE = 1000;
            newAsset2.NPA.HOUSE.AREA_OTHER_USAGE = 3000;
            newAsset2.NPA.HOUSE.AREA_TEMPORARY_HOUSE_USAGE = 100;
            newAsset2.NAME = "tài sản NPA House";
            newAsset2.ASSET_CATEGORY_ID = 1;
            newAsset2.ASSET_TYPE_ID = 22;
            newAsset2.CODE = "02";
            newAsset2.SYNC_SOURCE_ID = "1";
            newAsset2.SYNC_USER_ID = 1;
            newAsset2.UNIT_ID = 1;
            newAsset2.ID = 11;
            _dbContext.ASSETS.Add(newAsset2);



            var newAsset3 = new ASSET();
            newAsset3.NPA.VEHICLE.BRAND_NAME = "oto";
            newAsset3.NPA.VEHICLE.CAPACITY = "20000kg";
            newAsset3.NPA.VEHICLE.COUNTRY_OF_ORIGIN = "hà nội";
            newAsset3.NPA.VEHICLE.REGISTRATION_PLATE_NUMBER = "s/n12234823646";
            newAsset3.NPA.VEHICLE.SIZE = 12;
            newAsset3.NPA.VEHICLE.VEHICLE_IDENTIFICATION_NUMBER = "a2sx3fje";
            newAsset3.NAME = "tài sản NPA Vehicle";
            newAsset3.ASSET_CATEGORY_ID = 2;
            newAsset3.ASSET_TYPE_ID = 23;
            newAsset3.CODE = "03";
            newAsset3.SYNC_SOURCE_ID = "1";
            newAsset3.SYNC_USER_ID = 1;
            newAsset3.UNIT_ID = 1107;
            newAsset3.ID = 12;
            _dbContext.ASSETS.Add(newAsset3);

            var newAsset4 = new ASSET();
            newAsset4.NPA.OTHER_ASSET.BRAND_NAME = "tài khản khác";
            newAsset4.NPA.OTHER_ASSET.SPECIFICATIONS = "20000kg";
            newAsset4.NPA.OTHER_ASSET.COUNTRY_OF_ORIGIN = "hà nội";
            newAsset4.NPA.OTHER_ASSET.SERIAL_NUMBER = "s/n12234823646";
            newAsset4.NPA.OTHER_ASSET.SUPPLIER = "E.U";
            newAsset4.NAME = "tài sản NPA Other Asset";
            newAsset4.ASSET_CATEGORY_ID = 2;
            newAsset4.ASSET_TYPE_ID = 24;
            newAsset4.CODE = "04";
            newAsset4.SYNC_SOURCE_ID = "1";
            newAsset4.SYNC_USER_ID = 1;
            newAsset4.UNIT_ID = 1107;
            newAsset4.ID = 13;
            _dbContext.ASSETS.Add(newAsset4);

            var newAsset5 = new ASSET();
            newAsset5.OA.LAND.ADDRESS = "TP.HCM";
            newAsset5.OA.LAND.AREA = 3000000;
            newAsset5.OA.LAND.AREA_BUSINESS_USAGE = 50000;
            newAsset5.OA.LAND.AREA_LEASE_USAGE = 3000;
            newAsset5.NAME = "tài sản OA Land";
            newAsset5.ASSET_CATEGORY_ID = 1;
            newAsset5.ASSET_TYPE_ID = 25;
            newAsset5.CODE = "05";
            newAsset5.SYNC_SOURCE_ID = "1";
            newAsset5.SYNC_USER_ID = 1;
            newAsset5.UNIT_ID = 1;
            newAsset5.ID = 14;
            _dbContext.ASSETS.Add(newAsset5);



            var newAsset6 = new ASSET();
            newAsset6.OA.HOUSE.AREA_BUILDING = 10000;
            newAsset6.OA.HOUSE.AREA_BUSINESS_USAGE = 3000000;
            newAsset6.OA.HOUSE.AREA_FLOOR = 50000;
            newAsset6.OA.HOUSE.AREA_OCCUPIED_USAGE = 3000;
            newAsset6.OA.HOUSE.NUMBER_OF_FLOOR = 35000;
            newAsset6.NAME = "tài sản OA House";
            newAsset6.ASSET_CATEGORY_ID = 1;
            newAsset6.ASSET_TYPE_ID = 26;
            newAsset6.CODE = "06";
            newAsset6.SYNC_SOURCE_ID = "1";
            newAsset6.SYNC_USER_ID = 1;
            newAsset6.UNIT_ID = 1;
            newAsset6.ID = 15;
            _dbContext.ASSETS.Add(newAsset6);


            var newAsset7 = new ASSET();
            newAsset7.OA.VEHICLE.BRAND_NAME = "xe mới";
            newAsset7.OA.VEHICLE.CAPACITY = "N/A";
            newAsset7.OA.VEHICLE.COUNTRY_OF_ORIGIN = "a";
            newAsset7.OA.VEHICLE.REGISTRATION_PLATE_NUMBER = "ssnab243df";
            newAsset7.OA.VEHICLE.SIZE = 30;
            newAsset7.OA.VEHICLE.VEHICLE_IDENTIFICATION_NUMBER = "a3cx5g56h";
            newAsset7.NAME = "tài sản OA VEHICLE";
            newAsset7.ASSET_CATEGORY_ID = 1;
            newAsset7.ASSET_TYPE_ID = 27;
            newAsset7.CODE = "07";
            newAsset7.SYNC_SOURCE_ID = "1";
            newAsset7.SYNC_USER_ID = 1;
            newAsset7.UNIT_ID = 1;
            newAsset7.ID = 16;
            _dbContext.ASSETS.Add(newAsset7);


            var newAsset8 = new ASSET();
            newAsset8.OA.ABOVE_500M_ASSET.BRAND_NAME = "tài sản trên 500m";
            newAsset8.OA.ABOVE_500M_ASSET.SERIAL_NUMBER = "N/A";
            newAsset8.OA.ABOVE_500M_ASSET.COUNTRY_OF_ORIGIN = "a";
            newAsset8.OA.ABOVE_500M_ASSET.SPECIFICATIONS = "ssnab243df";
            newAsset8.OA.ABOVE_500M_ASSET.SUPPLIER = "China";
            newAsset8.NAME = "tài sản OA trên 500m";
            newAsset8.ASSET_CATEGORY_ID = 1;
            newAsset8.ASSET_TYPE_ID = 28;
            newAsset8.CODE = "08";
            newAsset8.SYNC_SOURCE_ID = "1";
            newAsset8.SYNC_USER_ID = 1;
            newAsset8.UNIT_ID = 1;
            newAsset8.ID = 17;
            _dbContext.ASSETS.Add(newAsset8);



            var newAsset9 = new ASSET();
            newAsset9.OA.BELOW_500M_ASSET.BRAND_NAME = "tài sản dưới 500m";
            newAsset9.OA.BELOW_500M_ASSET.SERIAL_NUMBER = "N/A";
            newAsset9.OA.BELOW_500M_ASSET.COUNTRY_OF_ORIGIN = "a";
            newAsset9.OA.BELOW_500M_ASSET.SPECIFICATIONS = "ssnab243df";
            newAsset9.OA.BELOW_500M_ASSET.SUPPLIER = "China";
            newAsset9.NAME = "tài sản OA dưới 500m";
            newAsset9.ASSET_CATEGORY_ID = 1;
            newAsset9.ASSET_TYPE_ID = 29;
            newAsset9.CODE = "09";
            newAsset9.SYNC_SOURCE_ID = "1";
            newAsset9.SYNC_USER_ID = 1;
            newAsset9.UNIT_ID = 1;
            newAsset9.ID = 18;
            _dbContext.ASSETS.Add(newAsset9);
            _dbContext.SaveChanges();

        }

        [TestMethod]
        public void InsertDataAssetMutation()
        {
            var mutationType = new ASSET_MUTATION_TYPE();
            mutationType.ID = 1;
            mutationType.CODE = "Tang";
            mutationType.NAME = "Tăng";
            _dbContext.ASSET_MUTATION_TYPES.Add(mutationType);
            var mutationType1 = new ASSET_MUTATION_TYPE();
            mutationType1.ID = 2;
            mutationType1.CODE = "Giam";
            mutationType1.NAME = "Giảm";
            _dbContext.ASSET_MUTATION_TYPES.Add(mutationType1);
            _dbContext.SaveChanges();




            var newAsset = new ASSET_MUTATION();
            newAsset.ASSET_CATEGORY_ID = 1;
            newAsset.ASSET_TYPE_ID = 21;
            newAsset.ASSET_CODE = "01";
            newAsset.SYNC_SOURCE_ID = "1";
            newAsset.SYNC_USER_ID = 1;
            newAsset.UNIT_ID = 1;
            newAsset.ASSET_ID = 10;
            newAsset.ID = 10;
            newAsset.ASSET_MUTATION_TYPE_ID = 1;
            newAsset.NPA.LAND.ADDRESS = "haf nooi ";
            newAsset.NPA.LAND.AREA = 1000000;
            newAsset.NPA.LAND.AREA_BUSINESS_USAGE = 10000;
            newAsset.ASSET_MUTATION_TYPE_ID = 1;

            newAsset.NAME = "tài sản NPA Land";

            _dbContext.ASSET_MUTATIONS.Add(newAsset);



            var newAsset2 = new ASSET_MUTATION();
            newAsset2.NPA.HOUSE.NUMBER_OF_FLOOR = 3200;
            newAsset2.NPA.HOUSE.AREA_BUILDING = 5400;
            newAsset2.NPA.HOUSE.AREA_BUSINESS_USAGE = 10000;
            newAsset2.NPA.HOUSE.AREA_FLOOR = 4000;
            newAsset2.NPA.HOUSE.AREA_HEADQUARTER_USAGE = 300;
            newAsset2.NPA.HOUSE.AREA_HOUSE_USAGE = 5000;
            newAsset2.NPA.HOUSE.AREA_WAREHOUSE_USAGE = 1000;
            newAsset2.NPA.HOUSE.AREA_OTHER_USAGE = 3000;
            newAsset2.NPA.HOUSE.AREA_TEMPORARY_HOUSE_USAGE = 100;
            newAsset2.NAME = "tài sản NPA House";
            newAsset2.ASSET_CATEGORY_ID = 1;
            newAsset2.ASSET_TYPE_ID = 22;
            newAsset2.ASSET_CODE = "02";
            newAsset2.SYNC_SOURCE_ID = "1";
            newAsset2.SYNC_USER_ID = 1;
            newAsset2.UNIT_ID = 1;
            newAsset2.ASSET_ID = 11;
            newAsset2.ID = 11;
            newAsset2.ASSET_MUTATION_TYPE_ID = 1;

            _dbContext.ASSET_MUTATIONS.Add(newAsset2);



            var newAsset3 = new ASSET_MUTATION();
            newAsset3.NPA.VEHICLE.BRAND_NAME = "oto";
            newAsset3.NPA.VEHICLE.CAPACITY = "20000kg";
            newAsset3.NPA.VEHICLE.COUNTRY_OF_ORIGIN = "hà nội";
            newAsset3.NPA.VEHICLE.REGISTRATION_PLATE_NUMBER = "s/n12234823646";
            newAsset3.NPA.VEHICLE.SIZE = 12;
            newAsset3.NPA.VEHICLE.VEHICLE_IDENTIFICATION_NUMBER = "a2sx3fje";
            newAsset3.NAME = "tài sản NPA Vehicle";
            newAsset3.ASSET_CATEGORY_ID = 2;
            newAsset3.ASSET_TYPE_ID = 23;
            newAsset3.ASSET_CODE = "03";
            newAsset3.SYNC_SOURCE_ID = "1";
            newAsset3.SYNC_USER_ID = 1;
            newAsset3.UNIT_ID = 1107;
            newAsset3.ASSET_ID = 12;
            newAsset3.ID = 12;
            newAsset3.ASSET_MUTATION_TYPE_ID = 1;

            _dbContext.ASSET_MUTATIONS.Add(newAsset3);

            var newAsset4 = new ASSET_MUTATION();
            newAsset4.NPA.OTHER_ASSET.BRAND_NAME = "tài khản khác";
            newAsset4.NPA.OTHER_ASSET.SPECIFICATIONS = "20000kg";
            newAsset4.NPA.OTHER_ASSET.COUNTRY_OF_ORIGIN = "hà nội";
            newAsset4.NPA.OTHER_ASSET.SERIAL_NUMBER = "s/n12234823646";
            newAsset4.NPA.OTHER_ASSET.SUPPLIER = "E.U";
            newAsset4.NAME = "tài sản NPA Other Asset";
            newAsset4.ASSET_CATEGORY_ID = 2;
            newAsset4.ASSET_TYPE_ID = 24;
            newAsset4.ASSET_CODE = "04";
            newAsset4.SYNC_SOURCE_ID = "1";
            newAsset4.SYNC_USER_ID = 1;
            newAsset4.UNIT_ID = 1107;
            newAsset4.ASSET_ID = 13;
            newAsset4.ID = 13;
            newAsset4.ASSET_MUTATION_TYPE_ID = 1;

            _dbContext.ASSET_MUTATIONS.Add(newAsset4);

            var newAsset5 = new ASSET_MUTATION();
            newAsset5.OA.LAND.ADDRESS = "TP.HCM";
            newAsset5.OA.LAND.AREA = 3000000;
            newAsset5.OA.LAND.AREA_BUSINESS_USAGE = 50000;
            newAsset5.OA.LAND.AREA_LEASE_USAGE = 3000;
            newAsset5.NAME = "tài sản OA Land";
            newAsset5.ASSET_CATEGORY_ID = 1;
            newAsset5.ASSET_TYPE_ID = 25;
            newAsset5.ASSET_CODE = "05";
            newAsset5.SYNC_SOURCE_ID = "1";
            newAsset5.SYNC_USER_ID = 1;
            newAsset5.UNIT_ID = 1;
            newAsset5.ASSET_ID = 14;
            newAsset5.ID = 14;
            newAsset5.ASSET_MUTATION_TYPE_ID = 2;

            _dbContext.ASSET_MUTATIONS.Add(newAsset5);



            var newAsset6 = new ASSET_MUTATION();
            newAsset6.OA.HOUSE.AREA_BUILDING = 10000;
            newAsset6.OA.HOUSE.AREA_BUSINESS_USAGE = 3000000;
            newAsset6.OA.HOUSE.AREA_FLOOR = 50000;
            newAsset6.OA.HOUSE.AREA_OCCUPIED_USAGE = 3000;
            newAsset6.OA.HOUSE.NUMBER_OF_FLOOR = 35000;
            newAsset6.NAME = "tài sản OA House";
            newAsset6.ASSET_CATEGORY_ID = 1;
            newAsset6.ASSET_TYPE_ID = 26;
            newAsset6.ASSET_CODE = "06";
            newAsset6.SYNC_SOURCE_ID = "1";
            newAsset6.SYNC_USER_ID = 1;
            newAsset6.UNIT_ID = 1;
            newAsset6.ASSET_ID = 15;
            newAsset6.ID = 15;
            newAsset6.ASSET_MUTATION_TYPE_ID = 2;

            _dbContext.ASSET_MUTATIONS.Add(newAsset6);


            var newAsset7 = new ASSET_MUTATION();
            newAsset7.OA.VEHICLE.BRAND_NAME = "xe mới";
            newAsset7.OA.VEHICLE.CAPACITY = "N/A";
            newAsset7.OA.VEHICLE.COUNTRY_OF_ORIGIN = "a";
            newAsset7.OA.VEHICLE.REGISTRATION_PLATE_NUMBER = "ssnab243df";
            newAsset7.OA.VEHICLE.SIZE = 30;
            newAsset7.OA.VEHICLE.VEHICLE_IDENTIFICATION_NUMBER = "a3cx5g56h";
            newAsset7.NAME = "tài sản OA VEHICLE";
            newAsset7.ASSET_CATEGORY_ID = 1;
            newAsset7.ASSET_TYPE_ID = 27;
            newAsset7.ASSET_CODE = "07";
            newAsset7.SYNC_SOURCE_ID = "1";
            newAsset7.SYNC_USER_ID = 1;
            newAsset7.UNIT_ID = 1;
            newAsset7.ASSET_ID = 16;
            newAsset7.ID = 16;
            newAsset7.ASSET_MUTATION_TYPE_ID = 1;

            _dbContext.ASSET_MUTATIONS.Add(newAsset7);


            var newAsset8 = new ASSET_MUTATION();
            newAsset8.OA.ABOVE_500M_ASSET.BRAND_NAME = "tài sản trên 500m";
            newAsset8.OA.ABOVE_500M_ASSET.SERIAL_NUMBER = "N/A";
            newAsset8.OA.ABOVE_500M_ASSET.COUNTRY_OF_ORIGIN = "a";
            newAsset8.OA.ABOVE_500M_ASSET.SPECIFICATIONS = "ssnab243df";
            newAsset8.OA.ABOVE_500M_ASSET.SUPPLIER = "China";
            newAsset8.NAME = "tài sản OA trên 500m";
            newAsset8.ASSET_CATEGORY_ID = 1;
            newAsset8.ASSET_TYPE_ID = 28;
            newAsset8.ASSET_CODE = "08";
            newAsset8.SYNC_SOURCE_ID = "1";
            newAsset8.SYNC_USER_ID = 1;
            newAsset8.UNIT_ID = 1;
            newAsset8.ASSET_ID = 17;
            newAsset8.ID = 17;
            newAsset8.ASSET_MUTATION_TYPE_ID = 1;
            
            _dbContext.ASSET_MUTATIONS.Add(newAsset8);



            var newAsset9 = new ASSET_MUTATION();
            newAsset9.OA.BELOW_500M_ASSET.BRAND_NAME = "tài sản dưới 500m";
            newAsset9.OA.BELOW_500M_ASSET.SERIAL_NUMBER = "N/A";
            newAsset9.OA.BELOW_500M_ASSET.COUNTRY_OF_ORIGIN = "a";
            newAsset9.OA.BELOW_500M_ASSET.SPECIFICATIONS = "ssnab243df";
            newAsset9.OA.BELOW_500M_ASSET.SUPPLIER = "China";
            newAsset9.NAME = "tài sản OA dưới 500m";
            newAsset9.ASSET_CATEGORY_ID = 1;
            newAsset9.ASSET_TYPE_ID = 29;
            newAsset9.ASSET_CODE = "09";
            newAsset9.SYNC_SOURCE_ID = "1";
            newAsset9.SYNC_USER_ID = 1;
            newAsset9.UNIT_ID = 1;
            newAsset9.ASSET_ID = 18;
            newAsset9.ID = 18;
            newAsset9.ASSET_MUTATION_TYPE_ID = 1;
            _dbContext.ASSET_MUTATIONS.Add(newAsset9);




            _dbContext.SaveChanges();

        }


    }

    public class MyProfile : Profile
    {
        public MyProfile()
        {
            SourceMemberNamingConvention = new UpperUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();


            CreateMap<ASSET, AssetNpaLandDetailDto>();
            //.ForMember(dest => dest.NPALandAddress, mo => mo.MapFrom(src => src.NPA.LAND.ADDRESS))
            //.ReverseMap();
        }
    }

    public class MyProfile2 : Profile
    {
        public MyProfile2()
        {
            SourceMemberNamingConvention = new PascalCaseNamingConvention();
            DestinationMemberNamingConvention = new UpperUnderscoreNamingConvention();


            CreateMap<AssetNpaLandDetailDto, ASSET>()
                .ForPath(dest => dest.NPA.LAND.ADDRESS, mo => mo.MapFrom(src => src.NPALandAddress));
        }
    }

    public class UpperUnderscoreNamingConvention : INamingConvention
    {
        public Regex SplittingExpression { get; } = new Regex(@"[\p{Lu}0-9]+(?=_?)");

        public string SeparatorCharacter { get { return "_"; } }

        public string ReplaceValue(Match match) => match.Value.ToUpper();
    }

    public class AssetNpaLandDetailDto
    {
        /// <summary>
        /// thoong tin chung
        /// </summary>
        public long Id { get; set; }
        public string NPALandAddress { get; set; }
        public string NpaTest { get; set; }
        public string NPATest { get; set; }
        public int AssetCategoryId { get; set; }
    }

    public class Level1Source
    {
        public int Id { get; set; }
        public Level2Source Level2 { get; set; }
    }

    public class Level2Source
    {
        public Level3Source Level3 { get; set; }
    }

    public class Level3Source
    {
        public string Value { get; set; }
    }


    public class Level1Destination
    {
        public int Id { get; set; }
        public Level2Destination Level2 { get; set; }
    }

    public class Level2Destination
    {
        public Level3Destination Level3 { get; set; }
    }

    public class Level3Destination
    {
        public string Value { get; set; }
    }

    public class Destination
    {
        public int Id { get; set; }
        public string Level2Level3Value { get; set; }
    }
}
