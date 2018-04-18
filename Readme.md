# Api Rest .Net

This is a api rest ful powered by .net. I made this api for my futur xamarin test.

##Documentation

### Models

In first we need to have a model. To do this create a class into the Models folder.

for example i have create the devise model :

```csharp
public class Devise
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public double Taux { get; set; }

        public Devise()
        {
            this.Id = 0;
            this.Nom = "Euros";
            this.Taux = 1.2;
        }

        public Devise(int id, string nom, double taux)
        {
            this.Id = id;
            this.Nom = nom;
            this.Taux = taux;
        }
    }
```