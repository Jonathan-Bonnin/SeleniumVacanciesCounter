The expected values of the vacancies count are hardcoded, so it may change if the vacancies are updated.

Test passed when I ran them\*; if tests fail, the tester can manually check if the actual count is equal to the expected count.

I am aware that I could have gone deeper in the POM design pattern with for instance a Map and an Abstract parent page, but for the sake of this project I decided that it would complicate the solution for no real practical benefit.

The locator for the dropdowns could have been even more simple (and thus less fragile), but having a locator that's like `By.XPath("//*[text()='All departments']")` could have created more other issues, in case there would have been another element with this text, so I decided to find the element that contains this text within an element that has the "dropdown" class, I thought it was a good compromise and much better than a fragile XPath like `/html/body/div[1]/div/div[1]/div/div/div[1]/div/div[3]/div/div/button`. Selecting by ID would be ideal but IDs are not unique\*\*

\*  ![Successful Tests](/images/successful_tests.png)
\*\* ![IDs not unique](/images/ids_not_unique.png)
