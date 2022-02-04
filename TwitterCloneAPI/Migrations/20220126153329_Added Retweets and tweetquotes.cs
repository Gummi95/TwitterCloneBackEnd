using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitterCloneAPI.Migrations
{
    public partial class AddedRetweetsandtweetquotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuoteTweets",
                table: "Tweets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Retweets",
                table: "Tweets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuoteTweets",
                table: "Tweets");

            migrationBuilder.DropColumn(
                name: "Retweets",
                table: "Tweets");
        }
    }
}
