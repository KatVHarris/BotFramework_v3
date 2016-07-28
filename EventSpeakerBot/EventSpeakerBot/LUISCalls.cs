using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Text;

//Add dependencies 
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System.Text.RegularExpressions;


namespace EventSpeakerBot
{
    [LuisModel("6f9ab687-1635-4db5-a118-abc07d07b9b6", "f2b59c258e5042a3b265498b92acd8a8")]
    [Serializable]
    public class LUISCalls : LuisDialog<Object>
    {
        //Generate Method for every Intent in LUIS model
        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            //None is the default response
            string message = "Tell me which event or speaker would like to know about";
            //Can also respond with the following if you don't have a set default message- $"Sorry I did not understand: " + string.Join(", ", result.Intents.Select(i => i.Intent));

            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("CoreCommand")]
        public async Task CoreCommand(IDialogContext context, LuisResult result)
        {
            var reply = context.MakeMessage();
            reply.Text = "My core command is to make life better.";
            await context.PostAsync(reply);
            context.Wait(MessageReceived);
        }

        [LuisIntent("QueryName")]
        public async Task GetInformationOnX(IDialogContext context, LuisResult result)
        {
            var entitiesArray = result.Entities;

            var reply = context.MakeMessage();

            if (entitiesArray.Count >= 1)
            {
                foreach (var entityItem in result.Entities)
                {
                    if (entityItem.Type == "Presenters")
                    {
                        switch (entityItem.Entity)
                        {
                            case "kat harris":
                                reply.Text = "This is the information I have: \n\n" +
                                "Passionate About: Gaming, Virtual and Augmented Reality \n\n" +
                                "Katherine Harris is a Microsoft Technical Evangelist with expertise in game, virtual and augmented reality development based out of Los Angeles.As an evangelist Katherine gives several talks about the different aspects of game development, VR and AR as well as teaches developers how to use these technologies with the Microsoft Platform.She is also, the co-host of ImagineThis, a web series for students to learn about the tech industry, and The Game Dev Show.Katherine is first woman in the world to be certified on Unity, the popular 3D game engine, and has been developing games since college.Before giving public talks about technology, Katherine worked with several clients to port iPhone and Android games to the Windows platform. \n\n" +
                                "http://Katvharris.azurewebsites.net";

                                    reply.Attachments = new List<Attachment>();
                                reply.Attachments.Add(
                                 new HeroCard
                                 {
                                     Title = $"Katherine Harris",
                                     Subtitle = "Microsoft TE - D&I Social 3.0",
                                     Text = "Talk - AR/VR and Bots",
                                     Images = new List<CardImage>
                                    {
                                        new CardImage
                                        {
                                            Url = $"http://legalmovespodcast.com/wp-content/uploads/2015/11/Profile.jpg"
                                        }
                                    },
        
                                 }.ToAttachment()
                                    );


                                
                                break;
                            case "heather shapiro":
                                reply.Text = "This is the information I have: \n\n"+
                                    "Passionate About: Data Science, Machine Learning \n\n"+
                                    "Heather Shapiro is a Technical Evangelist in Microsoft's Developer Experience & Evangelism group, "+
                                    "where she educates developers on Microsoft's new technologies.In this role,"+
                                    "Heather works closely with students and developer communities across the "+
                                    "North East to understand the newest technologies and architectures. "+
                                    "Prior to becoming a Technical Evangelist, Heather completed her undergraduate degree at Duke "+
                                    "University and graduated in the Class of 2015.She received Bachelors of Science in Computer "+
                                    "Science and Statistical Science, and completed an Honors Thesis about employing Bayesian Approaches"+
                                    "to Understanding Music Popularity. \n\n"+
                                    "http://microheather.com";

                                reply.Attachments = new List<Attachment>();
                                reply.Attachments.Add(
                                 new HeroCard
                                 {
                                     Title = $"Heather Shapiro",
                                     Subtitle = "Microsoft TE - D&I Social 3.0",
                                     Text = "Talk - Machine Learning",
                                     Images = new List<CardImage>
                                    {
                                        new CardImage
                                        {
                                            Url = $"http://d24wuq6o951i2g.cloudfront.net/img/events/id/257/2579092/assets/9a3.Heather-Shapiro.jpg"
                                        }
                                    },

                                 }.ToAttachment()
                                    );



                                break;
                            case "gabrielle crevecoeur":
                                reply.Text = "This is the information I have: \n\n"+
                                    "Passionate About: Open Source Development, Robotics \n\n "+
                                    "Gabrielle Crevecoeur is a Technical Evangelist at Microsoft specializing in open source development.Her current focus is Node.js and robotics. Gabrielle recently graduated from the Florida State University with a Bachelor’s of Science in Computer Science, where she was an active member of the National Society of Black Engineers and the Zeta Omicron chapter of Alpha Kappa Alpha Sorority, Incorporated. She plans to pursue a master’s in Electrical Engineering in the near future.When she is not working, you can find her playing video games or catching a dance class. You can find updates on her projects and interests at nowayshecodes.com  ";

                                reply.Attachments = new List<Attachment>();
                                reply.Attachments.Add(
                                 new HeroCard
                                 {
                                     Title = $"Gabrielle Crevecoeur",
                                     Subtitle = "Microsoft TE - D&I Social 3.0",
                                     Text = "Talk - IoT Elsa",
                                     Images = new List<CardImage>
                                    {
                                        new CardImage
                                        {
                                            Url = $"https://s3.amazonaws.com/strangeloop/uploadedimgs/prod/q6UiswHVc6eLDq-m_BH4Rg_large.jpg"
                                        }
                                    },

                                 }.ToAttachment()
                                    );
                                break;
                            case "marc spiotta":
                                reply.Text = "This is the information I have: \n\n" +
                                    "General Manager, US App & Cloud Developer Recruit \n\n" +
                                    "As General Manager for Microsoft's US App & Cloud Developer Recruit, Marc is responsible for leading an organization of " +
                                    "Business Development & Technical Specialists focused on driving the adoption of the Microsoft Platform by App Developers and " +
                                    "Independent Software Vendors (ISVs) for both the Consumer and Commercial markets. The App & Cloud Recruit Team helps Developers " +
                                    "leverage Microsoft's Cloud Platform to grow & accelerate their business.App Developers can expedite their time to market and increase the overall value proposition of their Solutions via the Microsoft Platform, including Microsoft Azure, Office 365, Windows, and SQL." +
                                    "\n\n" +
                                    "Born & raised in New Jersey, Marc studied English Literature at the University of Colorado - Boulder.He currently lives in Morristown, NJ with his wife, Melissa, and their 11 - year - old daughter, Makena.Outside of work, Marc & his family are very active in the local community, travel, and enjoy spending as much time as possible in and around the Ocean.";

                                reply.Attachments = new List<Attachment>();
                                reply.Attachments.Add(
                                 new HeroCard
                                 {
                                     Title = $"Marc Spiotta",
                                     Subtitle = "General Manager, US App & Cloud Developer Recruit",
                                     Text = "",
                                     Images = new List<CardImage>
                                    {
                                        new CardImage
                                        {
                                            Url = $"https://presentations.inxpo.com/FileLibrary/651/6/Marc1.jpg"
                                        }
                                    },

                                 }.ToAttachment()
                                    );
                                break;
                            default:
                                reply.Text = ("I have no information about that person. " +
                                    "");

                                break;
                        }

                    }
                }
            }
            await context.PostAsync(reply);
            context.Wait(MessageReceived);
        }

    }
}