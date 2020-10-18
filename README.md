# WebShopLibrary
C# TDD Implementation of simple WebShop (stand alone class library) using Nunit framework (3.12.0). </br>
Library's ShoppingBasket component allows customers to add products and display total cost and discounts.</br>
Everytime a total sum of price of basket is requested it is logged with all information as a file in C:\\temp\ShoppingBasketLog.</br>
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

<b>Scenarios </b>(Logs from file):</br></br>
![promisechains](https://github.com/domkris/files/blob/master/WebShopLibrary/ScenarioAll.png?raw=true)
