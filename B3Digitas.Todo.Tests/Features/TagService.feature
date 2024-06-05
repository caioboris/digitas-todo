Feature: TagService
  As a user
  I want to manage tags
  So that I can organize my tasks

  Scenario: Create a tag that already exists
    Given an existing tag with name "ExistingTag"
    When I try to create a tag with the same name
    Then the creation should fail with message "Essa etiqueta já existe!"

  Scenario: Create a new tag
    Given no existing tag with name "NewTag"
    When I create a tag with name "NewTag"
    Then the creation should succeed

  Scenario: Get a tag by ID that exists
    Given an existing tag with ID "c56a4180-65aa-42ec-a945-5fd21dec0538"
    When I get the tag by ID "c56a4180-65aa-42ec-a945-5fd21dec0538"
    Then the tag should be returned

  Scenario: Get a tag by ID that does not exist
    Given no existing tag with ID "c56a4180-65aa-42ec-a945-5fd21dec0538"
    When I get the tag by ID "c56a4180-65aa-42ec-a945-5fd21dec0538"
    Then the operation should fail with message "Etiqueta não encontrada."

  Scenario: Get all tags
    Given existing tags
    When I get all tags
    Then all tags should be returned

  Scenario: Update a tag that exists
    Given an existing tag with ID "c56a4180-65aa-42ec-a945-5fd21dec0538"
    When I update the tag with ID "c56a4180-65aa-42ec-a945-5fd21dec0538"
    Then the update should succeed

  Scenario: Update a tag that does not exist
    Given no existing tag with ID "c56a4180-65aa-42ec-a945-5fd21dec0538"
    When I update the tag with ID "c56a4180-65aa-42ec-a945-5fd21dec0538"
    Then the operation should fail with message "Erro ao atualizar etiqueta."

  Scenario: Delete a tag that exists
    Given an existing tag with ID "c56a4180-65aa-42ec-a945-5fd21dec0538"
    When I delete the tag with ID "c56a4180-65aa-42ec-a945-5fd21dec0538"
    Then the deletion should succeed

  Scenario: Delete a tag that does not exist
    Given no existing tag with ID "c56a4180-65aa-42ec-a945-5fd21dec0538"
    When I delete the tag with ID "c56a4180-65aa-42ec-a945-5fd21dec0538"
    Then the operation should fail with message "Etiqueta não encontrada."

  Scenario: Get a tag by title that exists
    Given an existing tag with name "TagByTitle"
    When I get the tag by title "TagByTitle"
    Then the tag should be returned

  Scenario: Get a tag by title that does not exist
    Given no existing tag with name "NonExistingTitle"
    When I get the tag by title "NonExistingTitle"
    Then the operation should fail with message "Etiqueta não encontrada."
