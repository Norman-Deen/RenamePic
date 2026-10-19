# 📦 Extract Largest Image from Render Zip Files

This utility extracts the **largest image file** from each `.zip` archive located in a specified directory. It's designed for zip files that contain folders named `_Render Pics` (or similar), often used in rendering workflows.

---

## ⚙️ How It Works

1. Scans the target directory for `.zip` files.
2. Extracts each `.zip` into a temporary subfolder.
3. Searches for a folder named `_Render Pics` inside the extracted contents.
4. Finds the **largest image** in that folder.
5. Copies and renames that image next to the original `.zip` file using the `.zip` filename.

---

## 🛠️ Configuration

Update the path in the code:

```csharp
string directoryPath = @"C:\path\to\your\folder";
```

This is where all your `.zip` files should be located.

---

## 📁 Example

* `Building01.zip` → contains `_Render Pics/`
* Inside `_Render Pics/`: `img1.jpg` (5MB), `img2.jpg` (2MB)
* Result: `Building01.jpg` will be copied next to `Building01.zip`

---

## 📦 Requirements

* .NET 6 or later
* Files must contain a folder with `_Render Pics` in the name
* The folder must contain image files (any extension)

---

## 👨‍💻 Author

Nour Tinawi — .NET Developer & 3D Artist
