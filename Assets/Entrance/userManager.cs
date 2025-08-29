using System.IO;
using UnityEngine;
using System.Collections.Generic;

public static class userManager {
    
    
    private static string desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
    private static string filePath = Path.Combine(desktopPath, "users.txt");

    public static bool SignUp(string username, string password, out string message) {
        Dictionary<string, string> users = LoadUsers();

        if (users.ContainsKey(username)) {
            message = "Username already exists!";
            return false;
        }

        File.AppendAllText(filePath, username + ":" + password + "\n");
        message = "Account created successfully!";
        return true;
    }

    public static bool LogIn(string username, string password, out string message) {
        Dictionary<string, string> users = LoadUsers();

        if (users.ContainsKey(username) && users[username] == password) {
            message = "Login successful!";
            return true;
        }

        message = "Invalid username or password!";
        return false;
    }

    private static Dictionary<string, string> LoadUsers() {
        Dictionary<string, string> users = new Dictionary<string, string>();

        if (!File.Exists(filePath)) {
            File.WriteAllText(filePath, "");
        }

        string[] lines = File.ReadAllLines(filePath);
        foreach (var line in lines) {
            if (!string.IsNullOrEmpty(line)) {
                string[] parts = line.Split(':');
                if (parts.Length == 2) {
                    users[parts[0]] = parts[1];
                }
            }
        }
        return users;
    }
}