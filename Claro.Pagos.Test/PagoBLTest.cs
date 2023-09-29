using Claro.Pagos.BE;
using Claro.Pagos.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Claro.Pagos.DAC;

namespace Claro.Pagos.Test
{
    [TestClass]
    public class PagoBLTest
    {



        //[TestMethod]
        //public void RetornaUnValorVerdaderoCuandoElRegistroFueExitoso()
        //{
        //    //Arrange
        //    PagoBE pago = new PagoBE();
        //    pago.cliente = "Fernando Ruiz";
        //    pago.importe = Convert.ToDecimal(120.50);
        //    pago.saldo = Convert.ToDecimal(20.50);
        //    pago.tipoComprobante = "BOLETA";

        //    List<TipoPagoBE> listaPagoBE = new List<TipoPagoBE>();
        //    TipoPagoBE tipo1 = new TipoPagoBE();
        //    tipo1.formaPago = "EFECTIVO";
        //    tipo1.numeroDocumento = "75124563";
        //    tipo1.montoPagado = Convert.ToDecimal(70);
        //    tipo1.pagoID = 1;
        //    listaPagoBE.Add(tipo1);

        //    TipoPagoBE tipo2 = new TipoPagoBE();
        //    tipo2.formaPago = "TARJETA";
        //    tipo2.numeroDocumento = "8542156325452147";
        //    tipo2.montoPagado = Convert.ToDecimal(80);
        //    tipo2.pagoID = 1;
        //    listaPagoBE.Add(tipo2);

        //    PagoBL pagoService = new PagoBL();
        //    bool estadoEsperado = true;
        //    bool estadoActual = false;

        //    //Act
        //    estadoActual = pagoService.Insertar(pago, listaPagoBE);

        //    //Assert

        //    //Assert.IsTrue(estadoActual);
        //    Assert.AreEqual(estadoEsperado, estadoActual);
        //}


        [TestClass]
        public class PagoBLTests
        {
            [TestMethod]
            public void RetornaUnValorVerdaderoCuandoElRegistroFueExitoso()
            {
                // Arrange
                var pagoDACMock = new Mock<PagoDAC>();
                var tipoPagoDACMock = new Mock<TipoPagoDAC>();

                var pagoBL = new PagoBL(pagoDACMock.Object, tipoPagoDACMock.Object);

                var pagoBE = new PagoBE(); // Crea una instancia de PagoBE
                var listaTipoPago = new List<TipoPagoBE>(); // Crea una lista de TipoPagoBE

                // Configura el comportamiento de los mocks
                pagoDACMock.Setup(dac => dac.Insertar(It.IsAny<PagoBE>())).Returns(1); // Simula un ID de pago válido
                tipoPagoDACMock.Setup(data => data.Insertar(It.IsAny<TipoPagoBE>())).Returns(true);
                // Act
                var resultado = pagoBL.Insertar(pagoBE, listaTipoPago);

                // Assert
                Assert.IsTrue(resultado);
               // pagoDACMock.Verify(dac => dac.Insertar(pagoBE), Times.Once);
               // tipoPagoDACMock.Verify(dac => dac.Insertar(It.IsAny<TipoPagoBE>()), Times.Exactly(listaTipoPago.Count));
            }
        }


    }
}
