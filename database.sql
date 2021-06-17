create table table_users
(
    id int primary key auto_increment,
    user_password text not null ,
    user_name varchar(20) not null unique,
    user_role text not null,
    user_status text not null
);
select * from table_users;

create table table_chat_archive
(
  id int primary key auto_increment,
  id_user int not null,
  msg_text text not null,
  date_time_msg text not null,
  id_chat text not null
);
select * from table_chat_archive;

select  id_user, msg_text, date_time_msg, id_chat
from table_users, table_chat_archive
where table_users.id = table_chat_archive.id_user
order by table_users.id;

create table table_chats
(
  id int primary key auto_increment,
  chat_name text not null,
  chat_status text not null
);
select * from table_chats;

create table table_users_in_chat
(
    id int primary key auto_increment,
    id_chat int not null,
    id_user text not null
);
select * from table_users_in_chat;

select chat_name, id_user, user_name, user_password, user_role, user_status
from table_users, table_chats, table_users_in_chat
where table_chats.id = table_users_in_chat.id_chat and
      table_users.id = table_users_in_chat.id_user;













