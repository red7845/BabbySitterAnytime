using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BabbySitterAnytime.Migrations
{
    /// <inheritdoc />
    public partial class seedAreas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("04b7a02b-b9c0-4bae-ac3e-d1753088739e"), "Ano Ilisia" },
                    { new Guid("06885121-ae03-4217-bf2a-718e58dc3de2"), "Kaisariani" },
                    { new Guid("09fa55b1-88b5-4717-b60f-4ffc3c3815c3"), "Kerameikos" },
                    { new Guid("0c652d85-eec8-43bc-b3eb-f699479f5d2c"), "Plaka" },
                    { new Guid("10012220-3c2d-4a39-bc7a-a40c4d0df4aa"), "Ano Petralona" },
                    { new Guid("13657cef-3d29-4150-b5ac-b5e0792f1f85"), "Moschato" },
                    { new Guid("14e54e2d-28f2-48ae-904c-87d63df47eca"), "Aghios Artemios" },
                    { new Guid("1587750d-a197-4d3d-bd82-61c0314ba787"), "Omonia" },
                    { new Guid("18ad1b27-0071-47e1-92a7-95d21aed578e"), "Alimos" },
                    { new Guid("18f2615e-69f4-4ba7-8f82-3136a804c82f"), "Thissio" },
                    { new Guid("1ddaee68-f7d1-46a6-9fe5-ad1002be7de9"), "Metaxourgeio" },
                    { new Guid("37b2faee-a946-4adf-8836-e69bf110e95e"), "Kypseli" },
                    { new Guid("38bd6914-0161-4878-b1ab-750951ae9097"), "Filothei" },
                    { new Guid("39cb9db7-d70e-4c14-83b9-d50dda1816c1"), "Melissia" },
                    { new Guid("3f363c0f-1c10-4eba-85a0-4300d7ca5672"), "Syntagma" },
                    { new Guid("40aa9582-4ac9-4ccf-bafe-94595dd6b8c5"), "Varvakeios" },
                    { new Guid("40d18919-aae2-487d-9511-a039b254d018"), "Agios Ioannis Rentis" },
                    { new Guid("487b1f39-9f34-4525-8990-233a4371ab4d"), "Exarchia" },
                    { new Guid("4adf3b99-0d31-4ad6-9abd-2b8b32326b6d"), "Ano Patisia" },
                    { new Guid("50480c85-9487-4a47-a31f-3fc2624889d0"), "Nikaia" },
                    { new Guid("54a58b24-da99-41a4-97ae-e0588545ffa5"), "Zografou" },
                    { new Guid("5d1ce6bc-7562-468b-9bbf-e10bb5b921e1"), "Ambelokipi" },
                    { new Guid("5f3b3580-0f36-4e95-a53a-943ea3e1c3d5"), "Monastiraki" },
                    { new Guid("5f736a16-3d54-46aa-803f-bf61d5fced7b"), "Koukaki" },
                    { new Guid("689c2951-0d36-4052-80b8-d6a087664fb8"), "Lykavittos" },
                    { new Guid("6c34a6de-ebe1-4c23-8dd9-fd56d96eac92"), "Vrilissia" },
                    { new Guid("6dd6eb55-247b-4cb4-8244-4e67e926e2b6"), "Kolonaki" },
                    { new Guid("72cfaa46-a09c-4a4f-9cf6-b9f889ab6f99"), "Nea Smyrni" },
                    { new Guid("75243e70-e22d-4d88-963d-280a1f575fa7"), "Peristeri" },
                    { new Guid("76c3ed33-0f68-442e-97bf-62d2d6243a41"), "Piraeus" },
                    { new Guid("77752e25-cb26-4591-a692-0fa737094de7"), "Neos Kosmos" },
                    { new Guid("8002ec0a-d952-4a9f-ac30-b7e1aa4aebe8"), "Kato Patisia" },
                    { new Guid("8ebb7374-1f19-4d00-bea5-9602124000e2"), "Psychiko" },
                    { new Guid("9079ea1a-c399-41c2-b7aa-402b3bed2141"), "Votanikos" },
                    { new Guid("95959dee-8cd4-483c-86db-2eeedafb77c8"), "Petralona" },
                    { new Guid("9937c217-a408-46fc-9a3a-c1056a03888e"), "Gyzi" },
                    { new Guid("9a55f52e-e66f-47b4-8cc8-63c8e7151931"), "Gazi" },
                    { new Guid("a2d3aa6e-1094-49d5-b53b-f0904c5f1233"), "Psiri" },
                    { new Guid("a6d85545-7d8c-46ef-b37b-85c6b883b09a"), "Ano Liosia" },
                    { new Guid("aa8ced0d-7452-4086-b041-63bfad21493d"), "Glyfada" },
                    { new Guid("ab1a0f88-feae-48f4-995f-6395e433102a"), "Galatsi" },
                    { new Guid("aeda50e4-50ce-4015-b059-072dda7b7308"), "Kallithea" },
                    { new Guid("af3e9ef6-fbb9-4711-bdce-42be570f5aea"), "Palaio Faliro" },
                    { new Guid("b3f8983f-7aa1-4c0d-a6b1-453854e49791"), "Chalandri" },
                    { new Guid("b77c315f-50f6-4e2e-a636-95591f6b4bf2"), "Aghia Paraskevi" },
                    { new Guid("ba6c8d6a-b7c5-4bcb-9f22-bc249ac6fd6f"), "Tavros" },
                    { new Guid("bf3b356a-9a65-42b4-92e1-871fb2195751"), "Pangrati" },
                    { new Guid("cafbcd71-da01-4f3f-a407-6c983f063818"), "Neapoli" },
                    { new Guid("ce26b961-79db-466a-bc0b-749fa443c8ef"), "Agios Dimitrios" },
                    { new Guid("cecda879-819e-426b-b45a-83b33567b01d"), "Aghios Eleftherios" },
                    { new Guid("cf2084ec-d2ff-43aa-883e-88dbbff1200f"), "Marousi" },
                    { new Guid("d8781e34-00df-4c3e-9fb8-ebe435cf0465"), "Kaminia" },
                    { new Guid("de7d4735-4223-4f17-aa36-48a29bf86033"), "Ilisia" },
                    { new Guid("e0f6dbe3-d23a-42cb-9c91-f902fe52d387"), "Kifisia" },
                    { new Guid("e99fb141-7365-4385-87fd-927f93e2250c"), "Argyroupoli" },
                    { new Guid("ea7b6df5-a821-43ef-acb9-c81e5a5d01da"), "Elliniko" },
                    { new Guid("ed0a8e2e-03a6-40e0-9bf9-0a0524857971"), "Sepolia" },
                    { new Guid("ef1f665c-5f53-434a-8482-8aee380964d6"), "Rizoupoli" },
                    { new Guid("f93a1fea-ae0e-4007-9201-a069c9067184"), "Vouliagmeni" },
                    { new Guid("fbf31f4a-e9d6-4353-8b07-9f5f1a78687e"), "Agios Stefanos" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("04b7a02b-b9c0-4bae-ac3e-d1753088739e"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("06885121-ae03-4217-bf2a-718e58dc3de2"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("09fa55b1-88b5-4717-b60f-4ffc3c3815c3"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("0c652d85-eec8-43bc-b3eb-f699479f5d2c"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("10012220-3c2d-4a39-bc7a-a40c4d0df4aa"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("13657cef-3d29-4150-b5ac-b5e0792f1f85"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("14e54e2d-28f2-48ae-904c-87d63df47eca"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("1587750d-a197-4d3d-bd82-61c0314ba787"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("18ad1b27-0071-47e1-92a7-95d21aed578e"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("18f2615e-69f4-4ba7-8f82-3136a804c82f"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("1ddaee68-f7d1-46a6-9fe5-ad1002be7de9"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("37b2faee-a946-4adf-8836-e69bf110e95e"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("38bd6914-0161-4878-b1ab-750951ae9097"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("39cb9db7-d70e-4c14-83b9-d50dda1816c1"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("3f363c0f-1c10-4eba-85a0-4300d7ca5672"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("40aa9582-4ac9-4ccf-bafe-94595dd6b8c5"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("40d18919-aae2-487d-9511-a039b254d018"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("487b1f39-9f34-4525-8990-233a4371ab4d"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("4adf3b99-0d31-4ad6-9abd-2b8b32326b6d"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("50480c85-9487-4a47-a31f-3fc2624889d0"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("54a58b24-da99-41a4-97ae-e0588545ffa5"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("5d1ce6bc-7562-468b-9bbf-e10bb5b921e1"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("5f3b3580-0f36-4e95-a53a-943ea3e1c3d5"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("5f736a16-3d54-46aa-803f-bf61d5fced7b"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("689c2951-0d36-4052-80b8-d6a087664fb8"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("6c34a6de-ebe1-4c23-8dd9-fd56d96eac92"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("6dd6eb55-247b-4cb4-8244-4e67e926e2b6"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("72cfaa46-a09c-4a4f-9cf6-b9f889ab6f99"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("75243e70-e22d-4d88-963d-280a1f575fa7"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("76c3ed33-0f68-442e-97bf-62d2d6243a41"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("77752e25-cb26-4591-a692-0fa737094de7"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("8002ec0a-d952-4a9f-ac30-b7e1aa4aebe8"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("8ebb7374-1f19-4d00-bea5-9602124000e2"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("9079ea1a-c399-41c2-b7aa-402b3bed2141"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("95959dee-8cd4-483c-86db-2eeedafb77c8"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("9937c217-a408-46fc-9a3a-c1056a03888e"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("9a55f52e-e66f-47b4-8cc8-63c8e7151931"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("a2d3aa6e-1094-49d5-b53b-f0904c5f1233"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("a6d85545-7d8c-46ef-b37b-85c6b883b09a"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("aa8ced0d-7452-4086-b041-63bfad21493d"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("ab1a0f88-feae-48f4-995f-6395e433102a"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("aeda50e4-50ce-4015-b059-072dda7b7308"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("af3e9ef6-fbb9-4711-bdce-42be570f5aea"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("b3f8983f-7aa1-4c0d-a6b1-453854e49791"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("b77c315f-50f6-4e2e-a636-95591f6b4bf2"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("ba6c8d6a-b7c5-4bcb-9f22-bc249ac6fd6f"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("bf3b356a-9a65-42b4-92e1-871fb2195751"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("cafbcd71-da01-4f3f-a407-6c983f063818"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("ce26b961-79db-466a-bc0b-749fa443c8ef"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("cecda879-819e-426b-b45a-83b33567b01d"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("cf2084ec-d2ff-43aa-883e-88dbbff1200f"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("d8781e34-00df-4c3e-9fb8-ebe435cf0465"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("de7d4735-4223-4f17-aa36-48a29bf86033"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("e0f6dbe3-d23a-42cb-9c91-f902fe52d387"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("e99fb141-7365-4385-87fd-927f93e2250c"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("ea7b6df5-a821-43ef-acb9-c81e5a5d01da"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("ed0a8e2e-03a6-40e0-9bf9-0a0524857971"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("ef1f665c-5f53-434a-8482-8aee380964d6"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("f93a1fea-ae0e-4007-9201-a069c9067184"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("fbf31f4a-e9d6-4353-8b07-9f5f1a78687e"));
        }
    }
}
