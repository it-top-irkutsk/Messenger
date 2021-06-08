# SqlConnecting library for SQLite
Библиотека для взаимодействия с базой данных на сервере

## Свойства библиотеки SqlConnecting (Публичные)

```bool IsConnected { get; private set; }``` - состояние подключения к базе

## Методы библиотеки SqlConnecting
```SqlConnecting(string dataSource, string catalog, string userId, string password)```   
*Конструктор*, принимающий значения для подключения к базе данных

**dataSource** -  имя сервера на котором находится база данных  
**catalog** - имя базы данных к которую необходимо подключится   
**userID** - ID пользователя для подключения к базе данных  
**password** - пароль для подключения к базе данных  

***Пример***        
```SqlConnecting("WIN-50GP30FGO75", "Demodb", "sa", "demo123")```      
Произойдет присвоения значений:     
Имя сервера - "WIN-50GP30FGO75",    
Имя базы данных - "Demodb",     
ID пользователя - "sa", 
Пароль - "demo123"  

---

```ConnectTo ``` - позволяет осуществить подключение к базе данных

***Пример***        
```ConnectTo()```    
производит подключение к базе данных через заданные в конструкторе значения 

---    

```DisconnectFrom``` -  позволяет осуществить отключение от базы данных  

***Пример***    
```DisconnectFrom()```  
производит отключение от базы данных с значениями ранее задаными в конструкторе

---

```GetDataFrom(string tableName)```  **(В данный момент может читать ли 2 столбца в таблице)**     
позволяет получить данные из определенной таблицы в базе данных и возвращает значение в виде string 

**tableName** - название таблицы         

***Пример***      
```GetDataFrom("demoTable1")``` 
Вывод:
```
1       data1
2       data2
3       data3
4       data4
```

---

```AddDataTo(string tableName, string columnsNames, string data)```  
позволяет добавить данные в определенную таблицу в базе данных

**tableName** - название таблицы                                      
**columnsNames** - название столбцов в таблице (в порядке сопостовимом с data)                                 
**data** - что должно быть помещенное в таблицу                                     

***Пример***      
```AddDataTo("demoTable1", "id, dataname", "5, '" + "data6" + "' ")```  
Добавит значение data6 с id 5
Итог - таблице приобритет подобный вид:
```
id      dataname
1       data1
2       data2
3       data3
4       data4
5       data6
```

---

```UpdateDataIn(string tableName, string updatingData, string id)```  
позволяет заменить значения в таблице

**tableName** - название таблицы                                    
**updatingData** -  столбец и новое значение элемента столбца                           
**id** - id строки на которой будут изменения           

***Пример***      
```UpdateDataIn("demoTable1", "datanme='"+"data5"+"'", "5")```  
Изменит значение data6 с id 5, на data5 (там где id 5)  
Итог - таблице приобритет подобный вид:
```
id      dataname
1       data1
2       data2
3       data3
4       data4
5       data5  (замена data6 на data5)  ((замена значения где id=5 на data5))
```
---

```DeleteDataFrom(string tableName, string id)```  
позволяет удалить данные из таблицы

**tableName** - название таблицы                    
**id** - id строки на которой будут изменения           

***Пример***      
```DeleteDataFrom("stringName", "5")```
Удалит строку с id 5

Итог - таблице приобритет подобный вид:
```
id      dataname
1       data1
2       data2
3       data3
4       data4
```
---