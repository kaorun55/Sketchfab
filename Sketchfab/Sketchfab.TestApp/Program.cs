namespace Sketchfab.TestApp
{
    class Program
    {
        static void Main( string[] args )
        {
            try {
                //var dir = System.IO.Path.GetDirectoryName( "model" );
                //var title = System.IO.Path.GetFileNameWithoutExtension( dir );
                //var zip = dir + ".zip";

                // Create Path
                var dir = System.IO.Path.Combine( System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "model" );
                var title = System.IO.Path.GetFileNameWithoutExtension( dir );
                var zip = dir + ".zip";
                if ( System.IO.File.Exists( zip ) ) {
                    System.IO.File.Delete( zip );
                }

                // Create Zip File
                System.IO.Compression.ZipFile.CreateFromDirectory( dir, zip );

                // Upload model
                var url = SketchfabUploader.Upload( @"*** API token ***", zip, title );

                // Open model
                System.Diagnostics.Process.Start( url );

                System.Console.WriteLine("Succeess!!");
            }
            catch ( System.Exception ex ) {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}
