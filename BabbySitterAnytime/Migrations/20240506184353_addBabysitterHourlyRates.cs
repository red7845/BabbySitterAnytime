using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BabbySitterAnytime.Migrations
{
    /// <inheritdoc />
    public partial class addBabysitterHourlyRates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("045b7d54-153b-47b9-816b-5d409fab9924"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("0925fd83-12e3-46b2-b871-988cabee88c3"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("0d58f2a5-7811-40f6-8a00-ac241f3ff4f6"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("0e21a594-1514-41bc-9a17-231eaf964981"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("17d6e2aa-8a6c-4994-a629-249cffe0362e"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("18727d19-93f5-49df-86f3-b273145ad464"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("1d406e6f-8856-4a99-ae87-4cfe69ecd5c1"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("1d9d9ae3-bef1-4374-aaee-eefc14d83fd1"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("1f1a1bd0-0cfa-46fa-b9d5-5837a4979373"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("21d652c3-f550-43fd-a499-afafbea86af1"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("23c0d951-5442-4d57-a76e-8e4b6ec1bd13"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("243b6f67-39dc-43fa-89d7-6355021db78d"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("261f9af5-3b86-4bce-b1ab-b8294d172471"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("263f7aa7-ccc4-49fc-a363-15db04a25d14"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("288defe8-6d3e-468f-92dc-8487b869d43f"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("2b5b6792-cc41-4420-b11b-800e4b10409d"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("318fb0d5-841d-47b0-b477-e3bb6a20bede"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("33ce932a-7c6e-4db4-b652-aa86a16cbb5b"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("3a7805a8-486f-4113-9538-67e172fd74f8"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("44ac2306-8c24-481e-818d-aca9d0854c99"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("453ddb41-4d7d-4eae-bcc4-876a07ca27a6"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("48c27ff1-bfda-4773-afb5-0b0d9cdcaef2"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("48cceb01-548a-4437-b038-6bae346a6014"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("4a6d952c-2285-4b26-8cc8-3b651e6104e1"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("4f03d468-a782-495f-8580-17ceeaab1c70"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("4f9efb4c-fc84-44b2-aeaf-6a9991809009"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("55ee76dc-2ddc-4120-b58e-be2a8c7b3f1b"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("580e2d39-2cd6-46d4-8fce-2f6a98d73bac"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("5c3f8ce5-66da-4104-8c1f-40d58cb090b5"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("669482b3-c52a-41c7-87f2-3549eb19c377"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("68a2b965-4634-44ca-9bae-691a72336ff7"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("733a3cb4-247a-4076-ae83-8bed9782569a"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("75392fe5-2af9-4a3a-b32e-27fadfbc10a8"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("7b515601-5e47-4e32-9cfb-95e9a86ba149"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("7c39fb3e-a32c-41b8-bedc-f0d3deb68447"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("7c7b35c3-f141-4bb5-a8bb-194b78ec33d9"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("81f019bb-90b0-4a2c-8f5e-f72f1e1aa962"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("859ec619-cce9-4de1-a7d8-a5be4fe74c73"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("85d741bf-a86b-48ce-9e35-8f484064abba"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("8a33b94e-8188-4c6e-b885-f885e6b78e72"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("8b937be0-dad2-42f1-b1af-6acd7a256f8f"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("8bec9098-9b4b-4453-9303-22fea666e23f"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("8eb41ffe-d199-4e8d-813e-0b9af3410583"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("925d47af-4466-4e44-b661-353023188ec0"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("9711f858-2763-4127-a080-cd8544097856"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("9c1c9693-5c1a-4222-8ba7-98fe5f177504"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("a1662ff2-6e33-470b-a5e4-390ba9261934"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("a5eb26ba-28fe-4a44-96ed-c111c7ab0890"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("b5e9a153-3c2d-4c10-b35e-4f15a4afa8c8"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("b6766109-7fdf-4647-94f8-791e8215dc09"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("b9b27f5f-825f-454e-9cd4-f92ec5f6dd82"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("c45faaf8-19a5-4cfd-aeaa-85e50097e95e"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("d8a13c89-70f9-4a76-89ef-21b6e516af0b"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("dd4ed16e-1a55-4325-b147-efb7e6e4b5a5"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("e15179ec-e657-4e6d-8074-0c40b47ab472"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("e9c3fbd2-1bc6-438d-b49f-adcd50ab734a"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("e9eff8b5-6079-4b2c-9670-2ab0fc9a3e0a"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("ec1630a0-564b-417d-afc3-e3e36e096331"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("f35cc06a-6f1b-4c76-a32a-0c42b840e3d6"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("f83f414d-fe3b-4481-8535-f867af8c3707"));

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("053fd88a-d589-4d4c-a03b-54b3828dda60"), "Metaxourgeio" },
                    { new Guid("06fa6fca-10a1-473d-98d2-ce5a4a53011b"), "Kifisia" },
                    { new Guid("07313700-52c6-4444-9e20-97ef2f3c21fd"), "Kato Patisia" },
                    { new Guid("0ce4859e-f3f9-4e87-85e9-d3bb319a6bde"), "Zografou" },
                    { new Guid("12fd0629-92cf-4603-81cb-de98074746f3"), "Vouliagmeni" },
                    { new Guid("13264fd3-5fdd-4112-8d81-b4d990db6433"), "Votanikos" },
                    { new Guid("13aba1cc-d3e4-4ffe-b75c-87c50485952d"), "Syntagma" },
                    { new Guid("218a48c0-d5c3-439e-a8cb-e8b17aa38fa8"), "Kallithea" },
                    { new Guid("22841ec9-1369-414b-b078-22bb4a61e78f"), "Nikaia" },
                    { new Guid("2477400e-cc8e-4679-adde-0bba2de75fa2"), "Aghia Paraskevi" },
                    { new Guid("2b7d442e-383b-43f9-9c77-0897ea13df7e"), "Marousi" },
                    { new Guid("2be28ba8-c3bf-49bd-aad8-f80c291b7eeb"), "Agios Dimitrios" },
                    { new Guid("2cb68f18-6939-47a4-8b4e-7edeb678f733"), "Ano Liosia" },
                    { new Guid("2dbbcb57-7c1a-4dec-9546-630155f43603"), "Aghios Artemios" },
                    { new Guid("34ca5ff6-c796-4199-916b-b02b6bc68a1e"), "Kypseli" },
                    { new Guid("3640d2f0-5b81-4dff-8bc6-22ef59fff919"), "Nea Smyrni" },
                    { new Guid("39443851-ffa4-4681-bfcc-0fedc731a951"), "Ano Patisia" },
                    { new Guid("420cc3ad-5bc9-43d1-86a4-bc8c3aae98ae"), "Kolonaki" },
                    { new Guid("44ed4d80-2c46-4850-9678-cc5dce27a59c"), "Monastiraki" },
                    { new Guid("4527cc90-3da8-407b-84e6-cadedef87f21"), "Kaisariani" },
                    { new Guid("49f84dd6-d8c1-40f7-9c6f-9ef0cfb76a4a"), "Gazi" },
                    { new Guid("534a8f75-7517-4c6e-a9bd-314fbd009e75"), "Galatsi" },
                    { new Guid("5804b1cf-ab33-4606-beff-41aa3efee804"), "Thissio" },
                    { new Guid("61846144-75cd-4dc3-9ce6-e793019e681e"), "Ilisia" },
                    { new Guid("61f04c9e-52dc-403a-a349-8293d9a303de"), "Omonia" },
                    { new Guid("69059e03-2946-4bf8-9b91-ed693867b503"), "Exarchia" },
                    { new Guid("6f989abc-13ef-4041-9fe6-41319ed44b46"), "Psiri" },
                    { new Guid("735d976a-bd96-4a35-ae14-00997adef4cd"), "Chalandri" },
                    { new Guid("75ffd930-c4ea-4887-8fd1-84979c000619"), "Ano Ilisia" },
                    { new Guid("76eec9a4-5095-4634-b0ae-30aca071c103"), "Filothei" },
                    { new Guid("76f2330f-17eb-4172-96cc-ef7d54f791c1"), "Neos Kosmos" },
                    { new Guid("776ebaba-de33-4e0f-9784-76a81434035b"), "Koukaki" },
                    { new Guid("781cd93a-4563-4df7-b0f4-639815e0249e"), "Psychiko" },
                    { new Guid("7badb858-acd8-41de-99e3-2feced4c9bea"), "Kaminia" },
                    { new Guid("7e815b53-07a1-4875-8769-1484ea37ac7d"), "Gyzi" },
                    { new Guid("826a13da-68f1-4529-858d-af6782e46d9c"), "Agios Stefanos" },
                    { new Guid("89a581cf-8578-4dec-a065-60a7d7783bb9"), "Peristeri" },
                    { new Guid("8d4e6e47-1407-41ea-b5f5-3d1e80de5f0e"), "Tavros" },
                    { new Guid("92eec9ab-0f3d-4ffd-9fc8-c3ea607d085b"), "Alimos" },
                    { new Guid("992f16c7-3058-4150-b6f2-489b756eedc4"), "Ano Petralona" },
                    { new Guid("9aaaee39-b57e-498b-8590-ac9c09453eac"), "Lykavittos" },
                    { new Guid("9ec03a94-f394-4fbb-9227-f65ea365e0dc"), "Varvakeios" },
                    { new Guid("9ff6d0cf-6180-49e3-935a-0f57598d954b"), "Rizoupoli" },
                    { new Guid("a008d739-c0e0-4335-bed4-fe8160b468f6"), "Palaio Faliro" },
                    { new Guid("a25b1d7f-25b1-42f5-83ff-0e70c6ba6d0d"), "Piraeus" },
                    { new Guid("a2f34ab9-0526-4772-a384-36bfbc0ec024"), "Glyfada" },
                    { new Guid("a66572e5-2ae0-457d-9fcb-fc28c6ce4390"), "Argyroupoli" },
                    { new Guid("b0ed85d8-64b4-44c3-9501-48b07cad7e05"), "Melissia" },
                    { new Guid("bd5a57ff-7318-43a7-ae67-696e268ea9e3"), "Petralona" },
                    { new Guid("c32489f4-155e-4985-8a59-023a94f4d7b7"), "Vrilissia" },
                    { new Guid("c73a0768-5cfa-4e74-bdf5-a069bb9f4487"), "Kerameikos" },
                    { new Guid("cc35a789-9ade-4e1d-b2b9-4508caf19f61"), "Aghios Eleftherios" },
                    { new Guid("ce74cba2-079d-4b68-9494-a60591f96e0a"), "Elliniko" },
                    { new Guid("d62b3c73-37aa-4db9-865a-c692e7434c69"), "Neapoli" },
                    { new Guid("dbdd4886-33d5-477c-9cd7-e220d816e329"), "Pangrati" },
                    { new Guid("df046b0b-175a-4ed2-a8d8-5b61fe95a66d"), "Sepolia" },
                    { new Guid("e3e2f46c-aaea-4bc8-822d-8e0e6ed87dc8"), "Plaka" },
                    { new Guid("ec92d15d-7381-4e38-964e-db24868b7c70"), "Agios Ioannis Rentis" },
                    { new Guid("efbfe579-1a01-4263-9938-322c2fd7fcb9"), "Ambelokipi" },
                    { new Guid("f89c4101-8d97-4346-a882-bd9bb4ba6299"), "Moschato" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("053fd88a-d589-4d4c-a03b-54b3828dda60"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("06fa6fca-10a1-473d-98d2-ce5a4a53011b"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("07313700-52c6-4444-9e20-97ef2f3c21fd"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("0ce4859e-f3f9-4e87-85e9-d3bb319a6bde"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("12fd0629-92cf-4603-81cb-de98074746f3"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("13264fd3-5fdd-4112-8d81-b4d990db6433"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("13aba1cc-d3e4-4ffe-b75c-87c50485952d"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("218a48c0-d5c3-439e-a8cb-e8b17aa38fa8"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("22841ec9-1369-414b-b078-22bb4a61e78f"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("2477400e-cc8e-4679-adde-0bba2de75fa2"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("2b7d442e-383b-43f9-9c77-0897ea13df7e"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("2be28ba8-c3bf-49bd-aad8-f80c291b7eeb"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("2cb68f18-6939-47a4-8b4e-7edeb678f733"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("2dbbcb57-7c1a-4dec-9546-630155f43603"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("34ca5ff6-c796-4199-916b-b02b6bc68a1e"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("3640d2f0-5b81-4dff-8bc6-22ef59fff919"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("39443851-ffa4-4681-bfcc-0fedc731a951"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("420cc3ad-5bc9-43d1-86a4-bc8c3aae98ae"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("44ed4d80-2c46-4850-9678-cc5dce27a59c"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("4527cc90-3da8-407b-84e6-cadedef87f21"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("49f84dd6-d8c1-40f7-9c6f-9ef0cfb76a4a"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("534a8f75-7517-4c6e-a9bd-314fbd009e75"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("5804b1cf-ab33-4606-beff-41aa3efee804"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("61846144-75cd-4dc3-9ce6-e793019e681e"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("61f04c9e-52dc-403a-a349-8293d9a303de"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("69059e03-2946-4bf8-9b91-ed693867b503"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("6f989abc-13ef-4041-9fe6-41319ed44b46"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("735d976a-bd96-4a35-ae14-00997adef4cd"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("75ffd930-c4ea-4887-8fd1-84979c000619"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("76eec9a4-5095-4634-b0ae-30aca071c103"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("76f2330f-17eb-4172-96cc-ef7d54f791c1"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("776ebaba-de33-4e0f-9784-76a81434035b"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("781cd93a-4563-4df7-b0f4-639815e0249e"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("7badb858-acd8-41de-99e3-2feced4c9bea"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("7e815b53-07a1-4875-8769-1484ea37ac7d"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("826a13da-68f1-4529-858d-af6782e46d9c"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("89a581cf-8578-4dec-a065-60a7d7783bb9"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("8d4e6e47-1407-41ea-b5f5-3d1e80de5f0e"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("92eec9ab-0f3d-4ffd-9fc8-c3ea607d085b"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("992f16c7-3058-4150-b6f2-489b756eedc4"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("9aaaee39-b57e-498b-8590-ac9c09453eac"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("9ec03a94-f394-4fbb-9227-f65ea365e0dc"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("9ff6d0cf-6180-49e3-935a-0f57598d954b"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("a008d739-c0e0-4335-bed4-fe8160b468f6"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("a25b1d7f-25b1-42f5-83ff-0e70c6ba6d0d"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("a2f34ab9-0526-4772-a384-36bfbc0ec024"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("a66572e5-2ae0-457d-9fcb-fc28c6ce4390"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("b0ed85d8-64b4-44c3-9501-48b07cad7e05"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("bd5a57ff-7318-43a7-ae67-696e268ea9e3"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("c32489f4-155e-4985-8a59-023a94f4d7b7"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("c73a0768-5cfa-4e74-bdf5-a069bb9f4487"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("cc35a789-9ade-4e1d-b2b9-4508caf19f61"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("ce74cba2-079d-4b68-9494-a60591f96e0a"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("d62b3c73-37aa-4db9-865a-c692e7434c69"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("dbdd4886-33d5-477c-9cd7-e220d816e329"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("df046b0b-175a-4ed2-a8d8-5b61fe95a66d"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("e3e2f46c-aaea-4bc8-822d-8e0e6ed87dc8"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("ec92d15d-7381-4e38-964e-db24868b7c70"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("efbfe579-1a01-4263-9938-322c2fd7fcb9"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("f89c4101-8d97-4346-a882-bd9bb4ba6299"));

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("045b7d54-153b-47b9-816b-5d409fab9924"), "Aghios Eleftherios" },
                    { new Guid("0925fd83-12e3-46b2-b871-988cabee88c3"), "Psychiko" },
                    { new Guid("0d58f2a5-7811-40f6-8a00-ac241f3ff4f6"), "Gazi" },
                    { new Guid("0e21a594-1514-41bc-9a17-231eaf964981"), "Kypseli" },
                    { new Guid("17d6e2aa-8a6c-4994-a629-249cffe0362e"), "Kato Patisia" },
                    { new Guid("18727d19-93f5-49df-86f3-b273145ad464"), "Petralona" },
                    { new Guid("1d406e6f-8856-4a99-ae87-4cfe69ecd5c1"), "Tavros" },
                    { new Guid("1d9d9ae3-bef1-4374-aaee-eefc14d83fd1"), "Exarchia" },
                    { new Guid("1f1a1bd0-0cfa-46fa-b9d5-5837a4979373"), "Vrilissia" },
                    { new Guid("21d652c3-f550-43fd-a499-afafbea86af1"), "Palaio Faliro" },
                    { new Guid("23c0d951-5442-4d57-a76e-8e4b6ec1bd13"), "Gyzi" },
                    { new Guid("243b6f67-39dc-43fa-89d7-6355021db78d"), "Ano Petralona" },
                    { new Guid("261f9af5-3b86-4bce-b1ab-b8294d172471"), "Melissia" },
                    { new Guid("263f7aa7-ccc4-49fc-a363-15db04a25d14"), "Peristeri" },
                    { new Guid("288defe8-6d3e-468f-92dc-8487b869d43f"), "Koukaki" },
                    { new Guid("2b5b6792-cc41-4420-b11b-800e4b10409d"), "Ano Patisia" },
                    { new Guid("318fb0d5-841d-47b0-b477-e3bb6a20bede"), "Thissio" },
                    { new Guid("33ce932a-7c6e-4db4-b652-aa86a16cbb5b"), "Sepolia" },
                    { new Guid("3a7805a8-486f-4113-9538-67e172fd74f8"), "Syntagma" },
                    { new Guid("44ac2306-8c24-481e-818d-aca9d0854c99"), "Psiri" },
                    { new Guid("453ddb41-4d7d-4eae-bcc4-876a07ca27a6"), "Ilisia" },
                    { new Guid("48c27ff1-bfda-4773-afb5-0b0d9cdcaef2"), "Neapoli" },
                    { new Guid("48cceb01-548a-4437-b038-6bae346a6014"), "Kifisia" },
                    { new Guid("4a6d952c-2285-4b26-8cc8-3b651e6104e1"), "Pangrati" },
                    { new Guid("4f03d468-a782-495f-8580-17ceeaab1c70"), "Galatsi" },
                    { new Guid("4f9efb4c-fc84-44b2-aeaf-6a9991809009"), "Agios Stefanos" },
                    { new Guid("55ee76dc-2ddc-4120-b58e-be2a8c7b3f1b"), "Metaxourgeio" },
                    { new Guid("580e2d39-2cd6-46d4-8fce-2f6a98d73bac"), "Kaminia" },
                    { new Guid("5c3f8ce5-66da-4104-8c1f-40d58cb090b5"), "Aghios Artemios" },
                    { new Guid("669482b3-c52a-41c7-87f2-3549eb19c377"), "Moschato" },
                    { new Guid("68a2b965-4634-44ca-9bae-691a72336ff7"), "Aghia Paraskevi" },
                    { new Guid("733a3cb4-247a-4076-ae83-8bed9782569a"), "Kaisariani" },
                    { new Guid("75392fe5-2af9-4a3a-b32e-27fadfbc10a8"), "Kolonaki" },
                    { new Guid("7b515601-5e47-4e32-9cfb-95e9a86ba149"), "Chalandri" },
                    { new Guid("7c39fb3e-a32c-41b8-bedc-f0d3deb68447"), "Ano Ilisia" },
                    { new Guid("7c7b35c3-f141-4bb5-a8bb-194b78ec33d9"), "Zografou" },
                    { new Guid("81f019bb-90b0-4a2c-8f5e-f72f1e1aa962"), "Monastiraki" },
                    { new Guid("859ec619-cce9-4de1-a7d8-a5be4fe74c73"), "Piraeus" },
                    { new Guid("85d741bf-a86b-48ce-9e35-8f484064abba"), "Marousi" },
                    { new Guid("8a33b94e-8188-4c6e-b885-f885e6b78e72"), "Ambelokipi" },
                    { new Guid("8b937be0-dad2-42f1-b1af-6acd7a256f8f"), "Plaka" },
                    { new Guid("8bec9098-9b4b-4453-9303-22fea666e23f"), "Varvakeios" },
                    { new Guid("8eb41ffe-d199-4e8d-813e-0b9af3410583"), "Elliniko" },
                    { new Guid("925d47af-4466-4e44-b661-353023188ec0"), "Ano Liosia" },
                    { new Guid("9711f858-2763-4127-a080-cd8544097856"), "Nikaia" },
                    { new Guid("9c1c9693-5c1a-4222-8ba7-98fe5f177504"), "Alimos" },
                    { new Guid("a1662ff2-6e33-470b-a5e4-390ba9261934"), "Glyfada" },
                    { new Guid("a5eb26ba-28fe-4a44-96ed-c111c7ab0890"), "Votanikos" },
                    { new Guid("b5e9a153-3c2d-4c10-b35e-4f15a4afa8c8"), "Omonia" },
                    { new Guid("b6766109-7fdf-4647-94f8-791e8215dc09"), "Filothei" },
                    { new Guid("b9b27f5f-825f-454e-9cd4-f92ec5f6dd82"), "Neos Kosmos" },
                    { new Guid("c45faaf8-19a5-4cfd-aeaa-85e50097e95e"), "Rizoupoli" },
                    { new Guid("d8a13c89-70f9-4a76-89ef-21b6e516af0b"), "Agios Ioannis Rentis" },
                    { new Guid("dd4ed16e-1a55-4325-b147-efb7e6e4b5a5"), "Kallithea" },
                    { new Guid("e15179ec-e657-4e6d-8074-0c40b47ab472"), "Kerameikos" },
                    { new Guid("e9c3fbd2-1bc6-438d-b49f-adcd50ab734a"), "Vouliagmeni" },
                    { new Guid("e9eff8b5-6079-4b2c-9670-2ab0fc9a3e0a"), "Agios Dimitrios" },
                    { new Guid("ec1630a0-564b-417d-afc3-e3e36e096331"), "Argyroupoli" },
                    { new Guid("f35cc06a-6f1b-4c76-a32a-0c42b840e3d6"), "Lykavittos" },
                    { new Guid("f83f414d-fe3b-4481-8535-f867af8c3707"), "Nea Smyrni" }
                });
        }
    }
}
