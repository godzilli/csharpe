namespace ProjetoCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agenda",
                c => new
                    {
                        AgendaId = c.Int(nullable: false, identity: true),
                        Semana = c.String(),
                        CargaHoraria = c.String(),
                        InicioExpediente = c.String(),
                        CriadoEm = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AgendaId);
            
            CreateTable(
                "dbo.Autonomo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cpf = c.String(),
                        Rua = c.String(),
                        NumCasa = c.String(),
                        Cep = c.String(),
                        Bairro = c.String(),
                        Cidade = c.String(),
                        Estado = c.String(),
                        Telefone = c.String(),
                        Email = c.String(),
                        Senha = c.String(),
                        Foto = c.String(),
                        CriadoEm = c.DateTime(nullable: false),
                        Agenda_AgendaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agenda", t => t.Agenda_AgendaId, cascadeDelete: true)
                .Index(t => t.Agenda_AgendaId);
            
            CreateTable(
                "dbo.Servico",
                c => new
                    {
                        ServicoId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Categoria = c.String(),
                        Valor = c.Double(nullable: false),
                        CriadoEm = c.DateTime(nullable: false),
                        Autonomo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ServicoId)
                .ForeignKey("dbo.Autonomo", t => t.Autonomo_Id)
                .Index(t => t.Autonomo_Id);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cpf = c.String(),
                        Rua = c.String(),
                        NumCasa = c.String(),
                        Cep = c.String(),
                        Bairro = c.String(),
                        Cidade = c.String(),
                        Estado = c.String(),
                        Telefone = c.String(),
                        Email = c.String(),
                        Senha = c.String(),
                        Foto = c.String(),
                        CriadoEm = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Mensagem",
                c => new
                    {
                        MensagemId = c.Int(nullable: false, identity: true),
                        RemetenteId = c.Int(nullable: false),
                        DestinatarioId = c.Int(nullable: false),
                        Texto = c.String(),
                        CriadoEm = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MensagemId);
            
            CreateTable(
                "dbo.Solicitacao",
                c => new
                    {
                        SolicitacaoId = c.Int(nullable: false, identity: true),
                        Agendamento = c.String(),
                        Avaliacao = c.Double(nullable: false),
                        Comentario = c.String(),
                        CriadoEm = c.DateTime(nullable: false),
                        Autonomo_Id = c.Int(nullable: false),
                        Cliente_Id = c.Int(nullable: false),
                        Formulario_ServicoId = c.Int(),
                    })
                .PrimaryKey(t => t.SolicitacaoId)
                .ForeignKey("dbo.Autonomo", t => t.Autonomo_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cliente", t => t.Cliente_Id, cascadeDelete: true)
                .ForeignKey("dbo.Servico", t => t.Formulario_ServicoId)
                .Index(t => t.Autonomo_Id)
                .Index(t => t.Cliente_Id)
                .Index(t => t.Formulario_ServicoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Solicitacao", "Formulario_ServicoId", "dbo.Servico");
            DropForeignKey("dbo.Solicitacao", "Cliente_Id", "dbo.Cliente");
            DropForeignKey("dbo.Solicitacao", "Autonomo_Id", "dbo.Autonomo");
            DropForeignKey("dbo.Servico", "Autonomo_Id", "dbo.Autonomo");
            DropForeignKey("dbo.Autonomo", "Agenda_AgendaId", "dbo.Agenda");
            DropIndex("dbo.Solicitacao", new[] { "Formulario_ServicoId" });
            DropIndex("dbo.Solicitacao", new[] { "Cliente_Id" });
            DropIndex("dbo.Solicitacao", new[] { "Autonomo_Id" });
            DropIndex("dbo.Servico", new[] { "Autonomo_Id" });
            DropIndex("dbo.Autonomo", new[] { "Agenda_AgendaId" });
            DropTable("dbo.Solicitacao");
            DropTable("dbo.Mensagem");
            DropTable("dbo.Cliente");
            DropTable("dbo.Servico");
            DropTable("dbo.Autonomo");
            DropTable("dbo.Agenda");
        }
    }
}
