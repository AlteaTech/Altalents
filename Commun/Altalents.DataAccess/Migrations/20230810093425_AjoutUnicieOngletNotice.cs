#nullable disable

namespace Altalents.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AjoutUnicieOngletNotice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@" delete top(1) mn from MarqueNotices mn, ( select * from( select Count(1) c, MarqueId, OngletNoticeMarqueId from MarqueNotices group by MarqueId, OngletNoticeMarqueId) a  where c >1) tmp where 
 mn.MarqueId = tmp.MarqueId and mn.OngletNoticeMarqueId = tmp.OngletNoticeMarqueId;");

            migrationBuilder.DropIndex(
                name: "IX_MarqueNotices_MarqueId",
                table: "MarqueNotices");

            migrationBuilder.CreateIndex(
                name: "IX_MarqueNotices_MarqueId_OngletNoticeMarqueId",
                table: "MarqueNotices",
                columns: new[] { "MarqueId", "OngletNoticeMarqueId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MarqueNotices_MarqueId_OngletNoticeMarqueId",
                table: "MarqueNotices");

            migrationBuilder.CreateIndex(
                name: "IX_MarqueNotices_MarqueId",
                table: "MarqueNotices",
                column: "MarqueId");
        }
    }
}
