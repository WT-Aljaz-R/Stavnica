BEGIN;
DO $body$

    begin
        if not exists (select * from pg_catalog.pg_user where usename = 'stavnica_db') then
            create role stavnica_db with login encrypted password 'password';
        end if;
    end
$body$;

create schema if not exists stavnica_db;
alter schema stavnica_db owner to stavnica_db;
alter role stavnica_db set search_path = stavnica_db;

commit;