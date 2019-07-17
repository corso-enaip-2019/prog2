using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace P1901AspNetCore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hell`O World!");
            //});

            app.Use(async (context, next) =>
            {
                /* 1st MiddleWare. */

                PathString pth = context.Request.Path;
                QueryString qrstr = context.Request.QueryString;

                await context.Response.WriteAsync("\n");

                /* print dei livelli del path. */
                await context.Response.WriteAsync("PathString\t" + pth.ToString());
                await context.Response.WriteAsync("\n");
                foreach (string sngpth in GetListOfPathPartsFromString(pth.ToString()))
                {
                    await context.Response.WriteAsync("\n\t" + sngpth);
                }

                await context.Response.WriteAsync("\n\n");

                /* print delle singole URL-query. */
                await context.Response.WriteAsync("URL-QueryString\t" + qrstr.ToString());
                await context.Response.WriteAsync("\n");
                foreach (string qry in GetListOfQueriesFromString(qrstr.ToString()))
                {
                    await context.Response.WriteAsync("\n\t" + qry);
                }

                await context.Response.WriteAsync("\n\n");

                /* print delle query come JSON-in-line. */
                await context.Response.WriteAsync("JSON-in-line:");
                await context.Response.WriteAsync("\n");
                await context.Response.WriteAsync("{");

                List<(string, string)> keyValList = FromURLQueryString_ToKeyValIn_ListStringString(qrstr.ToString());
                (string, string) lastTpl = keyValList[keyValList.Count() - 1];

                foreach ((string, string) keyVal in keyValList)
                {
                    await context.Response.WriteAsync("\"");
                    await context.Response.WriteAsync(keyVal.Item1.ToString());
                    await context.Response.WriteAsync("\":\"");
                    await context.Response.WriteAsync(keyVal.Item2.ToString());
                    await context.Response.WriteAsync("\"");

                    await context.Response.WriteAsync((lastTpl.Item1 == keyVal.Item1) & (lastTpl.Item2 == keyVal.Item2) ? "" : ","); // Eliminazione dell'ultima ",".
                }

                await context.Response.WriteAsync("}\n");

                await context.Response.WriteAsync("\n\n");

                /* print delle query come JSON. */
                await context.Response.WriteAsync("JSON:");
                await context.Response.WriteAsync("\n");
                await context.Response.WriteAsync("{");

                List<(string, string)> keyValList0 = FromURLQueryString_ToKeyValIn_ListStringString(qrstr.ToString());
                (string, string) lastTpl0 = keyValList[keyValList.Count() - 1];

                foreach ((string, string) keyVal in keyValList0)
                {
                    await context.Response.WriteAsync("\n\t");
                    await context.Response.WriteAsync("\"");
                    await context.Response.WriteAsync(keyVal.Item1.ToString());
                    await context.Response.WriteAsync("\" : \"");
                    await context.Response.WriteAsync(keyVal.Item2.ToString());
                    await context.Response.WriteAsync("\"");
                    await context.Response.WriteAsync((lastTpl.Item1 == keyVal.Item1) & (lastTpl.Item2 == keyVal.Item2) ? " " : " , "); // Eliminazione dell'ultima ",".
                }

                await context.Response.WriteAsync("\n}\n");

                await context.Response.WriteAsync("\n\n");
            });
        }

        /* Se ci sono più "?", tutto quello ch'è a dx del secondo, viene ignorato. */
        List<string> GetURLPartsFromFullURLQuery(string inFullURLQuery)
        {
            List<string> outList = new List<string>();

            if (string.IsNullOrWhiteSpace(inFullURLQuery))
            {
                outList.Add(null); // non c'è path.
                outList.Add(null); // non c'è query.

                //throw new Exception("Non c'è URL.", ArgumentNullException);

                return outList;
            }

            if (inFullURLQuery.Contains('?'))
            {
                string[] splittedURL = inFullURLQuery.Split('?');
                outList.Add(splittedURL[0]); // parte sx dell'URL con il path.
                outList.Add(splittedURL[1]); // parte dx dell'URL con la query.
            }
            else
            {
                outList.Add(inFullURLQuery); // tutto l''URL è path.
                outList.Add(null); // non c'è query.
            }

            return outList; /* path e query */
        }

        List<string> GetListOfPathPartsFromString(string inURL)
        {
            List<string> outList = new List<string>();

            if (string.IsNullOrWhiteSpace(inURL))
            {
                outList.Add(null); // non c'è path.

                //throw new Exception("Non c'è path.", ArgumentNullException);
                return outList;
            }

            if (inURL.Contains('/'))
            {
                string[] splittedPath = inURL.Split('/');
                foreach (string pathLevel in splittedPath)
                {
                    outList.Add(pathLevel); // aggiungi il singolo "livello".
                }
            }
            else
            {
                outList.Add(inURL); // tutto l'URL ha un singolo path.
            }

            return outList; /* lista coi "livelli" del path. */
        }

        List<string> GetListOfQueriesFromString(string inQuery)
        {
            List<string> outList = new List<string>();

            inQuery = inQuery.Remove(0, 1); // Eliminazione del "?" iniziale.

            if (string.IsNullOrWhiteSpace(inQuery))
            {
                outList.Add(null); // non c'è URL.

                //throw new Exception("Non c'è URL.", ArgumentNullException);
                return outList;
            }

            if (inQuery.Contains('&'))
            {
                string[] splittedQuery = inQuery.Split('&');
                foreach (string querySection in splittedQuery)
                {
                    outList.Add(querySection); // singola query.
                }
            }
            else
            {
                outList.Add(inQuery); // tutto l'inQuery è una singola query.
            }

            return outList; /* lista con le singole query. */
        }

        List<(string, string)> FromURLQueryIn_ListStr_ToJSONQueryIn_ListStrStr(List<string> inList)
        {
            List<(string, string)> outList = new List<(string, string)>();

            foreach (string str in inList)
            {
                string[] splittedKeyValue = str.Split('&');
                outList.Add((splittedKeyValue[0], splittedKeyValue[1]));
            }
            return outList;
        }

        List<(string, string)> FromURLQueryString_ToKeyValIn_ListStringString(string inURLQueryString)
        {
            List<(string, string)> outList = new List<(string, string)>();
            List<string> wrkList = new List<string>();

            inURLQueryString = inURLQueryString.Remove(0, 1); // Eliminazione del "?" iniziale.

            if (string.IsNullOrWhiteSpace(inURLQueryString))
            {
                outList.Add(("null", "null")); // non c'è query.

                //throw new Exception("Non c'è URL.", ArgumentNullException);
            }
            else
            {
                if (inURLQueryString.Contains('&'))
                {
                    string[] splittedQuery = inURLQueryString.Split('&');
                    foreach (string querySection in splittedQuery)
                    {
                        wrkList.Add(querySection); // singola query.
                    }
                }
                else
                {
                    wrkList.Add(inURLQueryString); // tutto l'inQuery è una singola query.
                }
            }

            foreach (string str in wrkList)
            {
                string[] splittedKeyValue = str.Split('=');
                outList.Add((splittedKeyValue[0], splittedKeyValue[1]));
            }
            return outList;
        }
    }
}