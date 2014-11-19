namespace TeamJStats.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GameStats", "Player_Id", "dbo.Players");
            DropForeignKey("dbo.GameStats", "Team_Id", "dbo.Teams");
            DropIndex("dbo.GameStats", new[] { "Player_Id" });
            DropIndex("dbo.GameStats", new[] { "Team_Id" });
            CreateTable(
                "dbo.SeasonStats",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        GamesPlayed = c.Int(nullable: false),
                        AssistsPerGame = c.Double(nullable: false),
                        TurnOversPerGame = c.Double(nullable: false),
                        StealsPerGame = c.Double(nullable: false),
                        BlocksPerGame = c.Double(nullable: false),
                        PersonalFoulsPerGame = c.Double(nullable: false),
                        ReboundsPerGame = c.Double(nullable: false),
                        OffensiveReboundsPerGame = c.Double(nullable: false),
                        DefensiveReboundsPerGame = c.Double(nullable: false),
                        FieldGoalsAttemptedPerGame = c.Double(nullable: false),
                        FieldGoalsMadePerGame = c.Double(nullable: false),
                        FieldGoalPercentage = c.Double(nullable: false),
                        ThreePointFieldGoalsAttemptedPerGame = c.Double(nullable: false),
                        ThreePointFieldGoalsMadePerGame = c.Double(nullable: false),
                        ThreePointFieldGoalPercentage = c.Double(nullable: false),
                        FreeThrowsAttemptedPerGame = c.Double(nullable: false),
                        FreeThrowsMadePerGame = c.Double(nullable: false),
                        FreeThrowsPercentage = c.Double(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Archived = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Teams", "SeasonStats_Id", c => c.Long());
            AddColumn("dbo.Players", "SeasonStats_Id", c => c.Long());
            AlterColumn("dbo.GameStats", "Player_Id", c => c.Long(nullable: false));
            AlterColumn("dbo.GameStats", "Team_Id", c => c.Long(nullable: false));
            CreateIndex("dbo.Teams", "SeasonStats_Id");
            CreateIndex("dbo.GameStats", "Player_Id");
            CreateIndex("dbo.GameStats", "Team_Id");
            CreateIndex("dbo.Players", "SeasonStats_Id");
            AddForeignKey("dbo.Players", "SeasonStats_Id", "dbo.SeasonStats", "Id");
            AddForeignKey("dbo.Teams", "SeasonStats_Id", "dbo.SeasonStats", "Id");
            AddForeignKey("dbo.GameStats", "Player_Id", "dbo.Players", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GameStats", "Team_Id", "dbo.Teams", "Id", cascadeDelete: true);
            DropColumn("dbo.Teams", "GamesPlayed");
            DropColumn("dbo.Teams", "AssistsPerGame");
            DropColumn("dbo.Teams", "TurnOversPerGame");
            DropColumn("dbo.Teams", "StealsPerGame");
            DropColumn("dbo.Teams", "BlocksPerGame");
            DropColumn("dbo.Teams", "PersonalFoulsPerGame");
            DropColumn("dbo.Teams", "ReboundsPerGame");
            DropColumn("dbo.Teams", "OffensiveReboundsPerGame");
            DropColumn("dbo.Teams", "DefensiveReboundsPerGame");
            DropColumn("dbo.Teams", "FieldGoalsAttemptedPerGame");
            DropColumn("dbo.Teams", "FieldGoalsMadePerGame");
            DropColumn("dbo.Teams", "FieldGoalPercentage");
            DropColumn("dbo.Teams", "ThreePointFieldGoalsAttemptedPerGame");
            DropColumn("dbo.Teams", "ThreePointFieldGoalsMadePerGame");
            DropColumn("dbo.Teams", "ThreePointFieldGoalPercentage");
            DropColumn("dbo.Teams", "FreeThrowsAttemptedPerGame");
            DropColumn("dbo.Teams", "FreeThrowsMadePerGame");
            DropColumn("dbo.Teams", "FreeThrowsPercentage");
            DropColumn("dbo.Players", "PointsPerGame");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "PointsPerGame", c => c.Int(nullable: false));
            AddColumn("dbo.Teams", "FreeThrowsPercentage", c => c.Double(nullable: false));
            AddColumn("dbo.Teams", "FreeThrowsMadePerGame", c => c.Double(nullable: false));
            AddColumn("dbo.Teams", "FreeThrowsAttemptedPerGame", c => c.Double(nullable: false));
            AddColumn("dbo.Teams", "ThreePointFieldGoalPercentage", c => c.Double(nullable: false));
            AddColumn("dbo.Teams", "ThreePointFieldGoalsMadePerGame", c => c.Double(nullable: false));
            AddColumn("dbo.Teams", "ThreePointFieldGoalsAttemptedPerGame", c => c.Double(nullable: false));
            AddColumn("dbo.Teams", "FieldGoalPercentage", c => c.Double(nullable: false));
            AddColumn("dbo.Teams", "FieldGoalsMadePerGame", c => c.Double(nullable: false));
            AddColumn("dbo.Teams", "FieldGoalsAttemptedPerGame", c => c.Double(nullable: false));
            AddColumn("dbo.Teams", "DefensiveReboundsPerGame", c => c.Double(nullable: false));
            AddColumn("dbo.Teams", "OffensiveReboundsPerGame", c => c.Double(nullable: false));
            AddColumn("dbo.Teams", "ReboundsPerGame", c => c.Double(nullable: false));
            AddColumn("dbo.Teams", "PersonalFoulsPerGame", c => c.Double(nullable: false));
            AddColumn("dbo.Teams", "BlocksPerGame", c => c.Double(nullable: false));
            AddColumn("dbo.Teams", "StealsPerGame", c => c.Double(nullable: false));
            AddColumn("dbo.Teams", "TurnOversPerGame", c => c.Double(nullable: false));
            AddColumn("dbo.Teams", "AssistsPerGame", c => c.Double(nullable: false));
            AddColumn("dbo.Teams", "GamesPlayed", c => c.Int(nullable: false));
            DropForeignKey("dbo.GameStats", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.GameStats", "Player_Id", "dbo.Players");
            DropForeignKey("dbo.Teams", "SeasonStats_Id", "dbo.SeasonStats");
            DropForeignKey("dbo.Players", "SeasonStats_Id", "dbo.SeasonStats");
            DropIndex("dbo.Players", new[] { "SeasonStats_Id" });
            DropIndex("dbo.GameStats", new[] { "Team_Id" });
            DropIndex("dbo.GameStats", new[] { "Player_Id" });
            DropIndex("dbo.Teams", new[] { "SeasonStats_Id" });
            AlterColumn("dbo.GameStats", "Team_Id", c => c.Long());
            AlterColumn("dbo.GameStats", "Player_Id", c => c.Long());
            DropColumn("dbo.Players", "SeasonStats_Id");
            DropColumn("dbo.Teams", "SeasonStats_Id");
            DropTable("dbo.SeasonStats");
            CreateIndex("dbo.GameStats", "Team_Id");
            CreateIndex("dbo.GameStats", "Player_Id");
            AddForeignKey("dbo.GameStats", "Team_Id", "dbo.Teams", "Id");
            AddForeignKey("dbo.GameStats", "Player_Id", "dbo.Players", "Id");
        }
    }
}
