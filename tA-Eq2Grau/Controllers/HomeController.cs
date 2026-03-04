using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tA_Eq2Grau.Models;

namespace tA_Eq2Grau.Controllers;
    public class HomeController : Controller {
        /// <summary>
        ///    Calcular as raízes
        /// </summary>
        /// <param name="A">Parâmetro do x²</param>
        /// <param name="B">Parâmetro do x</param>
        /// <param name="C">Parâmetro independente</param>
        /// <returns>vista</returns>
        public IActionResult Index(string A,string B,string C) {
            /*
             * Algoritmo:
             * 1 -> Ler os parâmetros A, B, C
             * 2 -> Validar se os parâmetros são válidos
             *  2.1 -> A, B, e C são números
             *  2.2 -> A != 0
             * 3 -> Se tudo estiver bem, posso fazer o cálculo
             *  3.1 -> Calcular o DELTA
             *  3.2 -> Se DELTA >= 0, raízes reais
             *  3.3 -> Se DELTA <0, raízes complexas conjugadas
             *      3.3.1 -> Calcular as raízes complexas
             *  3.4 -> Informar o utilizador das raízes compelxas
             *  Senão, notificar o utilizador de como corrigir o problema
             */
            
            //2.1
            if (!float.TryParse(A, out float a))
            //A não é número
            //Falta ainda gerar a msg de erro,
            //para ajudar o utilizador a corrigir o problema
            {
                return View();
            }
            
            if (!float.TryParse(B, out float b))
                //B não é número
                //Falta ainda gerar a msg de erro,
                //para ajudar o utilizador a corrigir o problema
            {
                return View();
            }
            
            if (!float.TryParse(C, out float c))
                //C não é número
                //Falta ainda gerar a msg de erro,
                //para ajudar o utilizador a corrigir o problema
            {
                return View();
            }
            
            //falta avaliar se A é 0
            
            
            //3.1
            float delta = b * b - 4 * a * c;
            
            //3.2
            if (delta >= 0)
            {
                //3.2.1
                float x1 = (-b + MathF.Sqrt(delta)) / (2 * a);
                float x2 = (-b - MathF.Sqrt(delta)) / (2 * a);
                
                
                //3.4
                ViewBag.x1 = x1;
                ViewBag.x2 = x2;
            }


            return View();
        }
        public IActionResult Privacy() {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }