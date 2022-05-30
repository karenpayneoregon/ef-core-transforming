# About

When working with enum type use a `T4 template` so that if a new member is added or an existing one is renamed simply run the template to generate with changes followed by copying and pasting the .cs file to the model folder.

There are two examples in this folder.

Make sure if using one of the supplied templates to alter the connection string to match your database.

Here the database is `ForumExample`

```
var connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ForumExample;Integrated Security=True";
```