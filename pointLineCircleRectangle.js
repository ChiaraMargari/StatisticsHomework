document.addEventListener("DOMContentLoaded",function () {
    var canvas =document.getElementById("myCanvas");
    var ctx =canvas.getContext("2d");

    //distanze orizzontali tra le forme
    var offsetX = 30; //distanza tra la linea e il cerchio
    var lineWidth =100; // Larghezza della linea
    var circleWidth =100; //larghezza del cerchio
    var rectWidth = 100; //larghezza del rettangolo

    //linea
    ctx.beginPath();
    ctx.moveTo(50, 50);
    ctx.lineTo(50 +lineWidth, 50);
    ctx.stroke();

    //Spostamento della posizione X per il cerchio
    offsetX += lineWidth +30;

    //cerchio
    ctx.beginPath();
    ctx.arc(50 + offsetX + circleWidth / 2, 100, circleWidth / 2, 0, 2 * Math.PI);
    ctx.stroke();

    //spostamento della posizione X per il rettangolo
    offsetX += circleWidth + 30;

    //rettangolo
    ctx.strokeRect(50 + offsetX, 50, rectWidth, 50);

    // punto a sinistra del canvas
    ctx.fillStyle = "black";
    ctx.fillRect(10,100, 5,5);
});
