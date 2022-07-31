# qulix_test_proj
Test project for internship

Swagger configured, so by swagger you can use to test.

The project is not fully complete, but because of some reasons i could not pay more attention

Adding Text and Adding Photo requires to fill DTO of enity,
MOst importantly, authornickname shoould be filled with appropriate value - may be this is drawback of this project:


PhotoDTO
{
  "name": required,
  "createdAt": required,
  "authorName": required to be filled appropriate author name,
  "authorNickname": required to be filled appropriate author nick name,
  "cost": reuired,
  "numberOfSales": required,
  "rating": required,
  "link": "required to be filled as filepath of photo, as default provided,
  "size": required,
  Image: required and filled on default
}

TextDTO
{
  "name": required,
  "texts": required,
  "createdAt": required,
  "authorName": required to be filled appropriate author name,
  "authorNickname": required to be filled appropriate author nick name,
  "cost": reuired,
  "numberOfSales": required,
  "rating": required,
}

Rating

apart from ["exellent", "good", "not bad", "bad", "poor"], all strings are considered as zero value choices.

This is done for further upcoming or next level development

For example:
Excellent for 5 