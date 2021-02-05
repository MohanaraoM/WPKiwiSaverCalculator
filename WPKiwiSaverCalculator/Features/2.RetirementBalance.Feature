Feature:2.RetirementBalance

@prod
  Scenario Outline: To test KiwiSaver Retirement Calculator Projected Balance
    Given I want to navigate to KiwiSavercalculators page
    And I Navigate to Calculator form page
    When I fill in '<currentage>','<emplomentstatus>','<salary>','<memebercontribution>','<pir>','<balance>','<voluntarycontribution>','<voluntaryfrequency>','<riskprofile>','<savingsgoal>'
    Then I should get calculated projected balances

    Examples: 
      | currentage | emplomentstatus | salary | memebercontribution | pir   | balance | voluntarycontribution | voluntaryfrequency | riskprofile | savingsgoal |
      |         30 | Employed        |   8200 | 4%                  | 17.5% |         |                       |                    | High        |             |
      |         45 | Self-employed   |        |                     | 10.5% |  100000 |                    90 | Fortnightly        | Medium      |      290000 |
      |         55 | Not employed    |        |                     | 10.5% |  140000 |                    10 | Annually           | Medium      |      200000 |