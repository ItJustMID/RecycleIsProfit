using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] GameObject[] _pageTutorial;

    int _currentPage = 0;

    public void NextPage()
    {
        if (_currentPage == _pageTutorial.Length - 1) return;
        _pageTutorial[_currentPage].SetActive(false);
        _currentPage++;
        _pageTutorial[_currentPage].SetActive(true);
    }

    public void PreviousPage()
    {
        if (_currentPage < 1) return;
        _pageTutorial[_currentPage].SetActive(false);
        _currentPage--;
        _pageTutorial[_currentPage].SetActive(true);
    }
}