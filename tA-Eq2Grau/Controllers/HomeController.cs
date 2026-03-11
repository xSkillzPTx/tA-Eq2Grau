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
            if (A == null || B == null || C == null)
            {
                return View();
            }

            //2.1
            if (!float.TryParse(A, out float a))
            //A não é número
            {
                ViewBag.ErroA="Atenção: O valor de A que introduziu não é um número válido!";
                return View();
            }
            
            if (!float.TryParse(B, out float b))
                //B não é número
            {
                ViewBag.ErroB="Atenção: O valor de B que introduziu não é um número válido!";
                return View();
            }
            
            if (!float.TryParse(C, out float c))
                //C não é número
            {
                ViewBag.ErroC="Atenção: O valor de C que introduziu não é um número válido!";
                return View();
            }
            
            //2.2
            //Validar se A é 0
            if (a == 0)
            {
                ViewBag.ErroAe0 = "Atenção: O valor de A não pode ser 0";
                return View();
            }
            
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
            else
            {
                float parteReal = (-b / (2 * a));
                float parteImaginaria = MathF.Sqrt(-delta)/(2*a);
                ViewBag.x1 = parteReal + " + " + parteImaginaria + " i ";
                ViewBag.x2 = parteReal + " - " + parteImaginaria + " i ";
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