<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="WebApplication1.Inicio" %>
<!doctype html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../../../../favicon.ico">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <title>On Tour</title>

    <!-- Bootstrap core CSS -->
    <link href="../../dist/css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom styles for this template -->
    <link href="starter-template.css" rel="stylesheet">
</head>

<body>
    
        <nav class="navbar navbar-expand-md navbar-dark bg-dark fixed-top">
            <a class="navbar-brand" href="Inicio.aspx">OnTour - Viajes de Estudio</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarsExampleDefault" aria-controls="navbarsExampleDefault" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="collapse navbar-collapse" id="navbarsExampleDefault">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item active">
                        <a class="nav-link" href="DestinosPreferidos.aspx">Destinos Preferidos <span class="sr-only">(current)</span></a>
                    </li>

                </ul>
                <form class="form-inline my-2 my-lg-0">
                    <a class="nav-link" href="Registrate.aspx">Registrate </a>
                    <a class="nav-link" href="Login.aspx">LogIn </a>
                </form>
            </div>
        </nav>
 
        
    <div id="myCarousel" class="carousel slide" data-ride="carousel" >
        <ol class="carousel-indicators">
          <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
          <li data-target="#myCarousel" data-slide-to="1"></li>
          <li data-target="#myCarousel" data-slide-to="2"></li>
        </ol>
        <div class="carousel-inner">
          <div class="carousel-item active" >
            <img class="first-slide img-thumbnail" src="images/francia.jpg" alt="First slide" style="background-size: cover" >
            <div class="container">
              <div class="carousel-caption text-left">
               
              </div>
            </div>
          </div>
          <div class="carousel-item" >
            <img class="second-slide img-thumbnail" src="images/rio.jpg" alt="Second slide" style="background-size: cover">
            <div class="container">
              <div class="carousel-caption">
               
              </div>
            </div>
          </div>
          <div class="carousel-item" >
            <img class="third-slide img-thumbnail" src="images/italia.jpg" alt="Third slide" style="background-size: cover">
            <div class="container">
              <div class="carousel-caption text-right">
              
              </div>
            </div>
          </div>
        </div>
        <a class="carousel-control-prev" href="#myCarousel" role="button" data-slide="prev">
          <span class="carousel-control-prev-icon" aria-hidden="true"></span>
          <span class="sr-only">Previous</span>
        </a>
        <a class="carousel-control-next" href="#myCarousel" role="button" data-slide="next">
          <span class="carousel-control-next-icon" aria-hidden="true"></span>
          <span class="sr-only">Next</span>
        </a>
      </div>
  
    <!-- /.container -->

    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script>window.jQuery || document.write('<script src="../../assets/js/vendor/jquery-slim.min.js"><\/script>')</script>
    <script src="../../assets/js/vendor/popper.min.js"></script>
    <script src="../../dist/js/bootstrap.min.js"></script>
    <script src="scripts/bootstrap.min.js"></script>
    <script src="scripts/popper.min.js"></script>
    <script src="scripts/jquery-3.0.0.slim.min.js"></script>
 

</body>
</html>
