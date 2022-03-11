<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="ProyectoFinal.Pruebamaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <!-- Carousel Start -->
            <div id="carousel" class="carousel slide" data-ride="carousel">
                <ol class="carousel-indicators">
                    <li data-target="#carousel" data-slide-to="0" class="active"></li>
                    <li data-target="#carousel" data-slide-to="1"></li>
                    <li data-target="#carousel" data-slide-to="2"></li>
                </ol>
                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <img src="/Fotos Inicio/socio.jpg" alt="Carousel Image">
                        <div class="carousel-caption">
                            <h1 style="color:#FF0000" class="animated fadeInLeft">Tu socio de mayor confianza</h1>
                            <p  class="animated fadeInRight">Estamos para ayudarte.</p>
                           
                        </div>
                    </div>

                    <div class="carousel-item">
                        <img src="Fotos Inicio/empresa.jpg" alt="Carousel Image">
                        <div class="carousel-caption">
                            <h1 style="color:#076328" class="animated fadeInLeft">Empresas</h1>
                            <p class="animated fadeInRight">Obtén apoyo en todo momento.</p>
                            
                        </div>
                    </div>

                    <div class="carousel-item">
                        <img src="Fotos Inicio/Carrusel2.jpg" alt="Carousel Image">
                        <div class="carousel-caption">
                            <h1   style="color:#D0E13B" class="animated fadeInLeft">Empleados</h1>
                            <p class="animated fadeInRight">Estamos disponibles para tratar su caso.</p>

                        </div>
                    </div>
                </div>

                <a class="carousel-control-prev" href="#carousel" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Anterior</span>
                </a>
                <a class="carousel-control-next" href="#carousel" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Siguiente</span>
                </a>
            </div>
            <!-- Carousel End -->
                          
</asp:Content>
