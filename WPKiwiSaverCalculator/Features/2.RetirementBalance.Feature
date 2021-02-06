Feature:2.RetirementBalance

@prod
  Scenario Outline: To test KiwiSaver Retirement Calculator Projected Balance
    Given I want to navigate to KiwiSavercalculators page
    And I Navigate to Calculator form page
    When I fill in '<currentage>','<emplomentstatus>','<salary>','<memebercontribution>','<balance>','<voluntarycontribution>','<voluntaryfrequency>','<riskprofile>','<savingsgoal>'
    Then I should get calculated projected balances '<ExpectedBalance>'

    Examples: 
      | currentage | emplomentstatus | salary | memebercontribution | balance | voluntarycontribution | voluntaryfrequency | riskprofile  | savingsgoal | ExpectedBalance |
      | 30         | Employed        | 8200   | 4%                  |         |                       |                    | Defensive    |             | $52,693         |
      | 45         | Self-employed   |        |                     | 100000  | 90                    | Fortnightly        | Conservative | 290000      | $259,581        |
      | 55         | Not employed    |        |                     | 140000  | 10                    | Annually           | Balanced     | 200000      | $197,679        |