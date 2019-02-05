# Physical Unit System

**Disclaimer: This is a work in progress and doesn't work yet. It doesn't follow a coherent coding style or API and is likely to change.**

This system helps with modeling physical objects in code. It wraps double values into several physical dimensions, like time, length, mass or temperature and provides ways to do correct calculations.  
For example, you can divide a length by a time to get a velocity, but you can't add a length and a time. This way you will make less mistakes and have an easier time understanding the code.

Furthermore it implements the logic about physical units, so you won't have to implement conversions from Celsius to Kelvin over and over again. 

Lastly it supports multiple unit systems and converting them from and to strings. That way have an easier time parsing files and returning the physical value in your preferred measurement.

```csharp
public class Examples {

  public string Example() {
    Length size = "5 ft";
    return size.ToString(Length.Unit.Meter); // returns "1.524 m"
  }
}
```
