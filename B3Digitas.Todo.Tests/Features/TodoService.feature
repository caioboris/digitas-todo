Feature: TodoService
  As a user
  I want to manage my todo tasks
  So that I can keep track of my work

  Scenario: Create a todo that already exists
    Given an existing todo with title "ExistingTodo"
    When I try to create a todo with the same title
    Then the creation should fail with message "Essa tarefa ja existe!"

  Scenario: Create a new todo
    Given no existing todo with title "New Todo"
    When I create a todo with title "New Todo"
    Then the creation should succeed

  Scenario: Get a todo by ID that exists
    Given an existing todo with ID "c56a4180-65aa-42ec-a945-5fd21dec0538"
    When I get the todo by ID "c56a4180-65aa-42ec-a945-5fd21dec0538"
    Then the todo should be returned

  Scenario: Get a todo by ID that does not exist
    Given no existing todo with ID "c56a4180-65aa-42ec-a945-5fd21dec0538"
    When I get the todo by ID "c56a4180-65aa-42ec-a945-5fd21dec0538"
    Then the operation should fail with message "Tarefa nao encontrada."

  Scenario: Get all todos
    Given existing todos
    When I get all todos
    Then all todos should be returned

  Scenario: Update a todo that exists
    Given an existing todo with ID "c56a4180-65aa-42ec-a945-5fd21dec0538"
    When I update the todo with ID "c56a4180-65aa-42ec-a945-5fd21dec0538"
    Then the update should succeed

  Scenario: Delete a todo that exists
    Given an existing todo with ID "c56a4180-65aa-42ec-a945-5fd21dec0538"
    When I delete the todo with ID "c56a4180-65aa-42ec-a945-5fd21dec0538"
    Then the deletion should succeed
