create table table_chats
(
    id          int auto_increment
        primary key,
    chat_name   varchar(20) not null,
    chat_status varchar(10) not null
);

create table table_users
(
    id            int auto_increment
        primary key,
    user_name     varchar(25) not null,
    user_password varchar(25) not null,
    user_role     varchar(25) not null,
    user_status   varchar(25) not null
);

create table table_chat_archive
(
    id            int auto_increment
        primary key,
    id_user       int      not null,
    msg_text      text     not null,
    date_time_msg datetime not null,
    id_chat       int      not null,
    constraint table_chat_archive_table_chats_id_fk
        foreign key (id_chat) references table_chats (id),
    constraint table_chat_archive_table_users_id_fk
        foreign key (id_user) references table_users (id)
);

create table table_users_in_chat
(
    id      int auto_increment
        primary key,
    id_chat int not null,
    id_user int not null,
    constraint table_users_in_chat_table_chats_id_fk
        foreign key (id_chat) references table_chats (id),
    constraint table_users_in_chat_table_users_id_fk
        foreign key (id_user) references table_users (id)
);
