using System;
using System.Collections.Generic;

/// <summary>
/// MenuComponent에서 모든 메소드 구현함
/// </summary>
public abstract class MenuComponent
{
    /*
      MenuItem에서만 쓰거나 Menu에서만 쓸 수 있기에 기본적으로 에러 처리 해줌 
        -> 자기 역할에 맞지 않는 메소드는 오버라이드하지 않고 기본 구현 그대로 사용 가능
     */
    public void add(MenuComponent menuComponent)
    {
        throw new NotSupportedException();
    }

    public void remove(MenuComponent menuCompoent)
    {
        throw new NotSupportedException();
    }

    public MenuComponent getChild(int i)
    {
        throw new NotSupportedException();
    }

    public String getName()
    {
        throw new NotSupportedException();
    }

    public String getDescription()
    {
        throw new NotSupportedException();
    }

    public double getPrice()
    {
        throw new NotSupportedException();
    }

    public Boolean isVegetarian()
    {
        throw new NotSupportedException();
    }

    public void print()
    {
        throw new NotSupportedException();
    }

}

public class MenuItem : MenuComponent
{
    String name { get; set; }
    String description { get; set; }
    Boolean vegetarian { get; set; }
    double price { get; set; }

    public MenuItem(String name, String description, Boolean vegetarian, double price)
    {
        this.name = name;
        this.description = description;
        this.vegetarian = vegetarian;
        this.price = price;
    }

    public void print()
    {
        Console.WriteLine(" " + this.name);

        if (this.vegetarian)
        {
            Console.WriteLine("(v)");
        }
        Console.WriteLine(", ", this.price);
        Console.WriteLine("     -- ", this.description);
    }


 }

public class Menu : MenuComponent
{
    List<MenuComponent> menuComponents = new List<MenuComponent>();
    String name { get; set; }
    String description { get; set; }

    public Menu(String name, String description)
    {
        this.name = name;
        this.description = description;
    }

    public void add(MenuComponent menuComponent)
    {
        menuComponents.Add(menuComponent);
    }

    public void remove(MenuComponent menuComponent)
    {
        menuComponents.Remove(menuComponent);
    }

    public MenuComponent getChild(int i)
    {
        return menuComponents[i];
    }

    public void print()
    {
        Console.WriteLine("\n", name);
        Console.WriteLine(", ", description);
        Console.WriteLine("---------------");

        for(int i = 0; i < menuComponents.Count; i++)
        {
            menuComponents[i].print();
        }
    }
}

// 이 코드를 사용하는 클라이언트
public class Waitress
{
    MenuComponent allMenus { get;  set; }

    public Waitress(MenuComponent allMenus)
    {
        this.allMenus = allMenus;
    }

    // 메뉴 전체의 계층구조(모든 메뉴 및 메뉴 항목)를 출력하고 싶다면 그냥 최상위 메뉴의 print() 메소드만 호출하면 됨
    public void printMenu()
    {
        allMenus.print();
    }
}

public class MenuTestDrive
{
    static void Main(string[] args)
    {
        MenuComponent pancakeHouseMenu = new Menu("팬케이크 하우스 메뉴", "아침 메뉴");
        MenuComponent dinnerMenu = new Menu("객체마을 식당 메뉴", "점심 메뉴");
        MenuComponent cafeMenu = new Menu("카페 메뉴", "저녁 메뉴");
        MenuComponent dessertMenu = new Menu("디저트 메뉴", "디저트를 즐겨보세요.");

        MenuComponent allMenus = new Menu("전체 메뉴", "전체 메뉴");

        allMenus.add(pancakeHouseMenu);
        allMenus.add(dinnerMenu);
        allMenus.add(cafeMenu);

        // 메뉴 항목 추가
        dinnerMenu.add(new MenuItem(
            "파스타",
            "마리나라 소스 스파게, 효모빵도 드림",
            true,
            3.89
            ));
        dinnerMenu.add(dessertMenu);

        dessertMenu.add(new MenuItem(
            "애플 파이",
            "바삭한 크러스트에 바닐라 아스크림이 얹혀 있는 애플 파이",
            true,
            1.59
            ));

        // 메뉴 항목 추가
        Waitress waitress = new Waitress(allMenus);
        waitress.printMenu();

    }
}
 