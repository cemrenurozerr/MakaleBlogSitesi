using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogSitesi.Migrations
{
    /// <inheritdoc />
    public partial class hasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OkunmaSayisi",
                table: "Makaleler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "Konular",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(25)",
                oldMaxLength: 25);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "c6e11de1-3a6a-4334-ba69-c2e8a6f2eace");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22aa8193-47f1-4516-930d-9824971aa0a4", "AQAAAAIAAYagAAAAEO463SCRyKocbQ0BGXkOlF+t3klsDXFU4xLGyHpZ0qG0lx5E/XFjSRpXJuUjLBquCQ==", "0ad2f461-4c4d-4678-b74e-4bd412b4db0a" });

            migrationBuilder.InsertData(
                table: "Makaleler",
                columns: new[] { "MakaleID", "Baslik", "Icerik", "KullaniciId", "OkunmaSayisi", "OlusturulmaTarihi", "OrtalamaOkumaSuresi" },
                values: new object[,]
                {
                    { 1, "Felsefe Nedir?", "Felsefe, varlık, bilgi, ahlak, zihin ve dil gibi temel konuları sorgulayan ve bu konulara dair sistematik düşünceler geliştiren disiplinler bütünüdür. İnsanların evreni ve kendilerini anlamaya yönelik meraklarından doğmuştur. Akıl yürütme, eleştirel düşünme ve mantık kullanarak sorular sorar ve yanıtlar arar. Felsefe, hem bireysel hem de toplumsal düzeyde yaşamı derinlemesine inceleme çabasıdır.", 1, null, new DateTime(2024, 5, 27, 1, 20, 46, 614, DateTimeKind.Local).AddTicks(1096), "3 dakika" },
                    { 2, "Felsefe Neden Önemlidir?", "Felsefe, düşünme ve sorgulama becerilerini geliştirerek eleştirel düşünceyi teşvik eder. İnsanların dünyayı ve kendilerini daha iyi anlamalarına yardımcı olur, etik ve ahlaki sorulara yanıtlar arar, ve toplumsal sorunlara çözümler sunar. Bu nedenle, bireysel ve toplumsal gelişim için önemlidir.Felsefe, bilim, sanat ve politika gibi birçok alana temel oluşturur. Sorgulama ve mantık yeteneklerini geliştirir, insanın bilgiye, hakikate ve adalete ulaşma çabalarını destekler. Bu yüzden, eğitimde ve günlük yaşamda vazgeçilmezdir.", 1, null, new DateTime(2024, 5, 27, 1, 20, 46, 614, DateTimeKind.Local).AddTicks(1121), "5 dakika" },
                    { 3, "Psikoloji Nedir?", "Psikoloji, insan davranışlarını ve zihinsel süreçleri inceleyen bilim dalıdır. Bireylerin düşünce, duygu ve davranışlarını anlamaya ve açıklamaya çalışır. Biyolojik, sosyal, gelişimsel ve klinik perspektiflerden insan deneyimini değerlendirir. Psikoloji, terapi ve danışmanlık yoluyla ruh sağlığını iyileştirir, öğrenme süreçlerini ve insan ilişkilerini geliştirir.", 1, null, new DateTime(2024, 5, 27, 1, 20, 46, 614, DateTimeKind.Local).AddTicks(1124), "4 dakika" },
                    { 4, "Egzersizin Stres ve Anksiyete Üzerindeki Etkileri", "Modern yaşamın getirdiği stres ve anksiyete, bireylerin ruh sağlığı üzerinde ciddi etkiler yaratmaktadır. Bu çalışma, düzenli egzersizin stres ve anksiyete seviyeleri üzerindeki etkilerini incelemeyi amaçlamaktadır.Araştırma, 18-45 yaş arası 150 katılımcı ile yürütülmüştür. Katılımcılar, düzenli egzersiz yapanlar ve yapmayanlar olarak iki gruba ayrılmıştır. Egzersiz yapan grup haftada en az üç kez 30 dakika süreyle egzersiz yapmaktadır. Stres seviyeleri Perceived Stress Scale (PSS) ve anksiyete seviyeleri State-Trait Anxiety Inventory (STAI) ile ölçülmüştür.Araştırma sonuçlarına göre, düzenli egzersiz yapan katılımcıların stres ve anksiyete seviyeleri, egzersiz yapmayanlara göre anlamlı derecede düşük bulunmuştur. Egzersiz süresi arttıkça, stres ve anksiyete seviyelerinin daha da azaldığı gözlemlenmiştir.Araştırma, düzenli egzersizin stres ve anksiyete seviyelerini düşürmede önemli bir rol oynadığını ortaya koymuştur. Bu bulgular, ruh sağlığını koruma ve iyileştirme çabalarında egzersizin teşvik edilmesi gerektiğini göstermektedir. Sağlık profesyonelleri ve danışmanlar, bireylere düzenli egzersiz yapmalarını önererek, onların stres ve anksiyeteyle daha etkin bir şekilde başa çıkmalarına yardımcı olabilir.", 1, null, new DateTime(2024, 5, 27, 1, 20, 46, 614, DateTimeKind.Local).AddTicks(1126), "10 dakika" },
                    { 5, "Eğlencenin Bireysel ve Toplumsal Refah Üzerindeki Etkileri", "Eğlence, bireylerin günlük yaşam stresinden uzaklaşmalarını sağlayan ve genel refahı artıran önemli bir faaliyettir. Bu tez, eğlencenin bireysel mutluluk ve toplumsal bağlar üzerindeki etkilerini incelemeyi amaçlamaktadır.Anket ve gözlem yöntemleri kullanılarak 300 katılımcının eğlence alışkanlıkları, yaşam memnuniyeti ve sosyal ilişkileri değerlendirilmiştir.Araştırma sonuçlarına göre, düzenli eğlence etkinliklerine katılan bireyler, daha yüksek yaşam memnuniyeti ve daha güçlü sosyal bağlar bildirmiştir. Eğlence, sosyal etkileşimi artırarak toplumsal bütünleşmeye katkıda bulunmaktadır.Eğlence, bireysel ve toplumsal refahı artıran önemli bir unsurdur. Bu nedenle, bireylerin eğlenceye daha fazla zaman ayırmaları teşvik edilmelidir.", 1, null, new DateTime(2024, 5, 27, 1, 20, 46, 614, DateTimeKind.Local).AddTicks(1127), "5 dakika" },
                    { 6, "Eğitimde Teknolojinin Rolü ve Geleceği", "Teknolojinin hızla gelişmesi, eğitim alanında da önemli değişimlere yol açmıştır. Bu makale, teknolojinin eğitimdeki rolünü ve gelecekteki etkilerini ele almaktadır.Makale, dijital öğrenme araçlarının kullanımı, uzaktan eğitim trendleri, yapay zeka destekli öğrenme ve sanal gerçeklik gibi teknolojik yenilikler üzerinde durmaktadır.Teknolojinin eğitimde kullanımı, öğrencilerin öğrenme deneyimini zenginleştirirken öğretmenlerin de öğretim yöntemlerini geliştirmelerine olanak tanımaktadır. Uzaktan eğitim, özellikle pandemi döneminde önemli bir araç haline gelmiştir.Makale, yapay zeka, artırılmış gerçeklik ve kişiselleştirilmiş öğrenme gibi teknolojik gelişmelerin eğitimde daha da belirleyici olacağını vurgulamaktadır.Eğitimde teknolojinin etkin ve bilinçli bir şekilde kullanılması, öğrenme süreçlerini iyileştirirken gelecek nesillerin yeteneklerini şekillendirmede önemli bir role sahiptir. Bu nedenle, teknolojiye dayalı eğitim stratejileri geliştirmek ve uygulamak gereklidir.", 1, null, new DateTime(2024, 5, 27, 1, 20, 46, 614, DateTimeKind.Local).AddTicks(1129), "10 dakika" }
                });

            migrationBuilder.InsertData(
                table: "MakaleKonular",
                columns: new[] { "MakaleKonuID", "KonuID", "MakaleID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 3 },
                    { 4, 2, 4 },
                    { 5, 3, 5 },
                    { 6, 4, 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MakaleKonular",
                keyColumn: "MakaleKonuID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MakaleKonular",
                keyColumn: "MakaleKonuID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MakaleKonular",
                keyColumn: "MakaleKonuID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MakaleKonular",
                keyColumn: "MakaleKonuID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MakaleKonular",
                keyColumn: "MakaleKonuID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MakaleKonular",
                keyColumn: "MakaleKonuID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Makaleler",
                keyColumn: "MakaleID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Makaleler",
                keyColumn: "MakaleID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Makaleler",
                keyColumn: "MakaleID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Makaleler",
                keyColumn: "MakaleID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Makaleler",
                keyColumn: "MakaleID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Makaleler",
                keyColumn: "MakaleID",
                keyValue: 6);

            migrationBuilder.AlterColumn<int>(
                name: "OkunmaSayisi",
                table: "Makaleler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "Konular",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "597ed2a6-cd7d-4042-b6a4-b51b0009fd77");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34f3b022-89dc-4c4f-a88b-124e1c3cbef2", "AQAAAAIAAYagAAAAELuP2PJIEiCcnpSpFCYnB9m+0yblZwrEvWFQar+j57Y4eBkCm5uzVwOfQY9zRTg0yw==", "5e130fca-16b4-473c-97f7-0427ba357f74" });
        }
    }
}
