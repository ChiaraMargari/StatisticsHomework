using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public partial class Form1 : Form
{
    private List<Rect> objects;
    private Rect selectedRect;
    private bool isDragging;
    private bool isDraggingView;
    private bool isResizingBottomRight;
    private int lastMouseX;
    private int lastMouseY;

    public Form1()
    {
        InitializeComponent();
        InitializeObjects();
        isDragging = false;
        isDraggingView = false;
        isResizingBottomRight = false;
    }

    private void InitializeObjects()
    {
        objects = new List<Rect>
        {
            new Rect(80, 30, 550, 300, 1),
            new Rect(80, 370, 550, 300, 2),
            new Rect(800, 30, 550, 300, 3),
            new Rect(800, 370, 550, 300, 4)
        };
    }

    private void DrawRectangles()
    {
        var graphics = CreateGraphics();
        graphics.Clear(Color.White);

        foreach (var rect in objects)
        {
            rect.Draw(graphics);
        }
    }

    private Rect FindSelectedObject(int x, int y)
    {
        for (int i = objects.Count - 1; i >= 0; i--)
        {
            var rect = objects[i];
            if (x >= rect.X && x <= rect.X + rect.Width && y >= rect.Y && y <= rect.Y + rect.Height)
            {
                return rect;
            }
        }
        return null;
    }

    /// <summary>
    /// Gestisce l'evento di pressione del pulsante del mouse sulla form.
    /// </summary>
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        var mouseX = e.X;
        var mouseY = e.Y;

        // Se il pulsante sinistro del mouse è stato premuto.
        if (e.Button == MouseButtons.Left)
        {
            // Verifica se il mouse è vicino all'angolo in basso a destra di un rettangolo per ridimensionamento.
            foreach (var rect in objects)
            {
                if (
                    mouseX < rect.X + rect.Width + 10 &&
                    mouseX > rect.X + rect.Width - 10 &&
                    mouseY < rect.Y + rect.Height + 10 &&
                    mouseY > rect.Y + rect.Height - 10
                )
                {
                    // Abilita il ridimensionamento in basso a destra e imposta il rettangolo selezionato.
                    isResizingBottomRight = true;
                    selectedRect = rect;
                    lastMouseX = mouseX;
                    lastMouseY = mouseY;
                    break;
                }

                // Verifica se il mouse è all'interno di un rettangolo per trascinamento.
                if (
                    mouseX >= rect.X &&
                    mouseX <= rect.X + rect.Width &&
                    mouseY >= rect.Y &&
                    mouseY <= rect.Y + rect.Height
                )
                {
                    // Abilita il trascinamento e imposta il rettangolo selezionato.
                    selectedRect = rect;
                    isDragging = true;
                    lastMouseX = mouseX;
                    lastMouseY = mouseY;
                    break;
                }
            }
        }
        // Se il pulsante destro del mouse è stato premuto.
        else if (e.Button == MouseButtons.Right)
        {
            // Trova il rettangolo selezionato sotto il puntatore del mouse e abilita la vista trascinante.
            selectedRect = FindSelectedObject(mouseX, mouseY);
            if (selectedRect != null)
            {
                isDraggingView = true;
                lastMouseX = mouseX;
                lastMouseY = mouseY;
            }
        }
    }

    /// <summary>
    /// Gestisce l'evento di movimento del mouse sulla form.
    /// </summary>
    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        var mouseX = e.X;
        var mouseY = e.Y;

        // Se è in corso un'operazione di trascinamento.
        if (isDragging)
        {
            if (selectedRect != null)
            {
                // Calcola la variazione nelle coordinate del mouse e sposta il rettangolo corrispondente.
                var dx = mouseX - lastMouseX;
                var dy = mouseY - lastMouseY;
                selectedRect.MoveRect(dx, dy);
            }

            // Ridisegna i rettangoli sulla form.
            DrawRectangles();

            lastMouseX = mouseX;
            lastMouseY = mouseY;
        }
        // Se è in corso un'operazione di vista trascinante.
        else if (isDraggingView)
        {
            if (selectedRect != null)
            {
                // Ridisegna i rettangoli e sposta la vista del rettangolo selezionato.
                DrawRectangles();
                selectedRect.OffsetViewX += mouseX - lastMouseX;
                selectedRect.OffsetViewY += mouseY - lastMouseY;
                lastMouseX = mouseX;
                lastMouseY = mouseY;
            }
            else
            {
                // Ridisegna i rettangoli e sposta la vista di tutti i rettangoli.
                DrawRectangles();
                var dx = mouseX - lastMouseX;
                var dy = mouseY - lastMouseY;
                foreach (var rect in objects)
                {
                    rect.OffsetViewX += dx;
                    rect.OffsetViewY += dy;
                }
                lastMouseX = mouseX;
                lastMouseY = mouseY;
            }
        }
        // Se è in corso un'operazione di ridimensionamento in basso a destra.
        else if (isResizingBottomRight)
        {
            // Ridisegna i rettangoli.
            DrawRectangles();

            // Aggiorna le coordinate del rettangolo in base al movimento del mouse.
            selectedRect.GridXfin += mouseX - lastMouseX;
            selectedRect.GridYfin += mouseY - lastMouseY;
            selectedRect.Width += mouseX - lastMouseX;
            selectedRect.Height += mouseY - lastMouseY;

            lastMouseX = mouseX;
            lastMouseY = mouseY;
        }
    }

    /// <summary>
    /// Gestisce l'evento di rilascio del pulsante del mouse sulla form.
    /// </summary>
    private void Form1_MouseUp(object sender, MouseEventArgs e)
    {
        // Disabilita tutte le operazioni di trascinamento o ridimensionamento.
        isDragging = false;
        isDraggingView = false;
        isResizingBottomRight = false;
    }

    /// <summary>
    /// Gestisce l'evento di rotellina del mouse sulla form.
    /// </summary>
    private void Form1_MouseWheel(object sender, MouseEventArgs e)
    {
        // Se un rettangolo è selezionato, esegui lo zoom in base al movimento della rotellina.
        if (selectedRect != null)
        {
            var delta = e.Delta;
            var scale = delta > 0 ? -1 : 1;
            selectedRect.Zoom(scale);
            
            // Ridisegna i rettangoli sulla form.
            DrawRectangles();
            e.Handled = true;
        }
    }


    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        DrawRectangles();
    }

    public class Rect
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int GridSpacing { get; set; }
        public int GridXini { get; set; }
        public int GridXfin { get; set; }
        public int GridYini { get; set; }
        public int GridYfin { get; set; }
        public int GridScale { get; set; }
        public double OffsetViewX { get; set; }
        public double OffsetViewY { get; set; }
        public int Id { get; set; }

        public Rect(int x, int y, int width, int height, int id)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            GridSpacing = 8;
            GridXini = x;
            GridXfin = x + width;
            GridYini = y;
            GridYfin = y + height;
            GridScale = 1;
            OffsetViewX = 0.0;
            OffsetViewY = 0.0;
            Id = id;
        }
        /// <summary>
        /// Disegna il rettangolo su un oggetto Graphics specificato.
        /// </summary>
        /// <param name="graphics">Oggetto Graphics su cui disegnare il rettangolo.</param>

        public void Draw(Graphics graphics)
        {
            var pen = new Pen(Color.Black);

            var scaledWidth = (int)(Width * GridScale);
            var scaledHeight = (int)(Height * GridScale);

            var offsetX = (int)OffsetViewX;
            var offsetY = (int)OffsetViewY;

            var scaledX = X + offsetX;
            var scaledY = Y + offsetY;

            var scaledGridXini = GridXini + offsetX;
            var scaledGridXfin = GridXfin + offsetX;
            var scaledGridYini = GridYini + offsetY;
            var scaledGridYfin = GridYfin + offsetY;

            for (int x = scaledGridXini; x <= scaledGridXfin; x += GridSpacing)
            {
                graphics.DrawLine(pen, x, scaledGridYini, x, scaledGridYfin);
            }

            for (int y = scaledGridYini; y <= scaledGridYfin; y += GridSpacing)
            {
                graphics.DrawLine(pen, scaledGridXini, y, scaledGridXfin, y);
            }

            graphics.DrawRectangle(pen, scaledX, scaledY, scaledWidth, scaledHeight);

            pen.Dispose();
        }

        /// <summary>
        /// Sposta il rettangolo di una quantità specificata lungo gli assi X e Y.
        /// </summary>
        /// <param name="dx">Quantità di spostamento lungo l'asse X.</param>
        /// <param name="dy">Quantità di spostamento lungo l'asse Y.</param>
    
        public void MoveRect(int dx, int dy)
        {
            X += dx;
            Y += dy;
            GridXini += dx;
            GridXfin += dx;
            GridYini += dy;
            GridYfin += dy;
        }

        /// <summary>
        /// Regola la scala del rettangolo per ingrandirlo o ridurlo.
        /// </summary>
        /// <param name="scale">Quantità di scala da applicare al rettangolo.</param>
    
        public void Zoom(int scale)
        {
            GridScale += scale;
            if (GridScale < 1)
            {
                GridScale = 1;
            }
        }
    }
}
