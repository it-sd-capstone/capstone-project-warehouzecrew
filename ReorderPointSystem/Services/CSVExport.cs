using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ReorderPointSystem.Models;

namespace ReorderPointSystem.Services
{
    public static class CSVExport
    {
        // ---------------------------------------------------------
        // Utility: safely escape CSV fields (quotes, commas, etc.)
        // ---------------------------------------------------------
        private static string Escape(string value)
        {
            if (value == null)
                return "";

            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
                return $"\"{value.Replace("\"", "\"\"")}\"";

            return value;
        }

        // ---------------------------------------------------------
        // EXPORT ITEMS
        // ---------------------------------------------------------
        internal static string ExportItems(List<Item> items)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Id,CategoryId,Name,Description,CurrentAmount,ReorderPoint,MaxAmount,CreatedAt,LastUpdatedAt");

            foreach (var i in items)
            {
                sb.AppendLine(
                    $"{i.Id}," +
                    $"{i.CategoryId}," +
                    $"{Escape(i.Name)}," +
                    $"{Escape(i.Description)}," +
                    $"{i.CurrentAmount}," +
                    $"{i.ReorderPoint}," +
                    $"{i.MaxAmount}," +
                    $"{i.CreatedAt:yyyy-MM-dd HH:mm:ss}," +
                    $"{i.LastUpdatedAt:yyyy-MM-dd HH:mm:ss}"
                );
            }

            return sb.ToString();
        }

        // ---------------------------------------------------------
        // EXPORT CATEGORIES
        // ---------------------------------------------------------
        internal static string ExportCategories(List<Category> categories)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Id,Name");

            foreach (var c in categories)
            {
                sb.AppendLine($"{c.Id},{Escape(c.Name)}");
            }

            return sb.ToString();
        }

        // ---------------------------------------------------------
        // EXPORT REORDERS
        // ---------------------------------------------------------
        internal static string ExportReorders(List<Reorder> reorders)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Id,ItemId,Quantity,Status,CreatedAt");

            foreach (var r in reorders)
            {
                sb.AppendLine(
                    $"{r.Id}," +
                    $"{r.ItemId}," +
                    $"{r.Quantity}," +
                    $"{Escape(r.Status)}," +
                    $"{r.CreatedAt:yyyy-MM-dd HH:mm:ss}"
                );
            }

            return sb.ToString();
        }

        // ---------------------------------------------------------
        // EXPORT INVENTORY LOGS
        // ---------------------------------------------------------
        public static string ExportInventoryLogs(List<InventoryLog> logs)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Id,ItemId,QuantityChange,Type,CreatedAt");

            foreach (var log in logs)
            {
                sb.AppendLine(
                    $"{log.Id}," +
                    $"{log.ItemId}," +
                    $"{log.QuantityChange}," +
                    $"{Escape(log.Type)}," +
                    $"{log.CreatedAt:yyyy-MM-dd HH:mm:ss}"
                );
            }

            return sb.ToString();
        }
    }
}
