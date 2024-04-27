using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
   private readonly List<MenuItem> items = new List<MenuItem>(); 
   public string Name { get; }  
   public string Description { get; }
   public IReadOnlyList<MenuItem> Items => items.AsReadOnly();

   private MenuSection(MenuSectionId menuSectionId, string name, string description) : base(menuSectionId)
   {
       Name = name;
       Description = description;
   }

   public static MenuSection Create(string name, string description)
   {
       return new MenuSection(MenuSectionId.CreateUnique(), name, description);
   }
}