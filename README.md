# WebShopLibrary
C# TDD Implementation of simple WebShop (stand alone class library) using Nunit framework (3.12.0). </br>
Library's ShoppingBasket component allows customers to add products and display total cost and discount.</br>
Everytime a total sum of price of basket is requested it is logged with all information as a file in C:\\temp\ShoppingBasketLog.</br>

Solution contains:
* WebShop folder
  * Program.cs -> Main Class of Console App to run and play with ShoppingBasket functionalities
* WebShop.Library folder
  * ShoppingBasket.cs -> Main Library Class that contains all funcionalities
  * ShoppingBasketLog.cs -> Class that contains all funcionalities for generating WebShop logs 
* WebShop.Library.Test folder 
  * Unit tests made during development

<b>Products example:</b> </br>
| Products  | Price |
| ------------- | ------------- |
| Butter  | 0.80$  |
| Milk  | 1.15$  |
| Bread  | 1.0$  |

</br>

<b>Discounts:</b></br>
* Buy 2 butters and get one bread 50% off
* Buy 3 milks get the 4th milk for free 

<b>Scenarios </b>(Logs retrieved from generated file):</br></br>
![promisechains](https://github.com/domkris/files/blob/master/WebShopLibrary/ScenarioAll.png?raw=true)
