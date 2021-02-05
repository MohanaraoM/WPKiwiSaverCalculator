Feature:Calculator Information Icon

@prod
  Scenario: Information Icon of Current Age
    Given I want to navigate to KiwiSavercalculators page
    And I Navigate to Calculator form page
    When I click on the help icon next to Current age textbox
    Then Help Messgae is shown on page